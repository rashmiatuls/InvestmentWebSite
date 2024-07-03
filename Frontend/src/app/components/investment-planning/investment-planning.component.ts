import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvestmentService } from '../../services/investment-planning.service';
import { Investment, InvestmentViewModel } from '../../models/investment-planning.model';

@Component({
  selector: 'app-investment-planning',
  templateUrl: './investment-planning.component.html',
  styleUrls: ['./investment-planning.component.css']
})
export class InvestmentPlanningComponent implements OnInit {
  investments: Investment[] = [];
  investmentForm: FormGroup;
  isEditMode = false;
  selectedInvestmentId: number | null = null;
  responseMessage: string = '';

  constructor(private fb: FormBuilder, private investmentService: InvestmentService) {
    this.investmentForm = this.fb.group({
      investmentName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      initialInvestmentAmount: [0, [Validators.required, Validators.min(0.01)]],
      investmentStartDate: ['', Validators.required],
      currentValue: [0],
      investorId: [0, Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadInvestments();
  }

  loadInvestments(): void {
    this.investmentService.getAllInvestments().subscribe(data => {
      this.investments = data;
    });
  }

  handleCreateInvestment(): void {
    if (this.investmentForm.valid) {
      this.investmentService.createInvestment(this.investmentForm.value).subscribe(response => {
        this.responseMessage = response.message;
        this.loadInvestments();
        this.investmentForm.reset();
      });
    }
  }

  handleUpdateInvestment(): void {
    if (this.investmentForm.valid && this.selectedInvestmentId !== null) {
      const updatedInvestment: InvestmentViewModel = { 
        ...this.investmentForm.value, 
        investmentId: this.selectedInvestmentId 
      };
      this.investmentService.updateInvestment(updatedInvestment).subscribe(response => {
        this.responseMessage = response.message;
        this.loadInvestments();
        this.investmentForm.reset();
        this.isEditMode = false;
        this.selectedInvestmentId = null;
      });
    }
  }

  handleEditInvestment(id: number): void {
    this.selectedInvestmentId = id;
    const investment = this.investments.find(inv => inv.investmentId === id);
    if (investment) {
      this.isEditMode = true;
      this.investmentForm.patchValue(investment);
    }
  }

  handleDeleteInvestment(id: number): void {
    this.investmentService.deleteInvestment(id).subscribe(response => {
      this.responseMessage = response.message;
      this.loadInvestments();
    });
  }

  isCreateButtonDisabled(): boolean {
    return this.investmentForm.invalid;
  }
}
