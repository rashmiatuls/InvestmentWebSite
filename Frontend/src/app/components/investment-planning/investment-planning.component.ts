import { Component, OnInit } from '@angular/core';
import { InvestmentService } from '../../services/investment-planning.service';
import { Investment } from '../../models/investment-planning.model';

@Component({
  selector: 'app-investment-planning',
  templateUrl: './investment-planning.component.html',
  styleUrls: ['./investment-planning.component.css']
})
export class InvestmentPlanningComponent implements OnInit {
  investments: Investment[] = [];
  filteredInvestments: Investment[] = [];
  investment: Investment = {
    investmentId: 0,
    investmentName: '',
    initialInvestmentAmount: 0,
    investmentStartDate: new Date(),
    currentValue: 0,
    investorId: 0
  };
  selectedId: number | null = null;
  categories: string[] = [];
  selectedCategory: string = '';
  responseMessage: string = '';

  constructor(private investmentService: InvestmentService) { }

  ngOnInit(): void {
    // write your logic here
  }

  loadInvestments(): void {
    // write your logic here
  }

  handleInputChange(event: any): void {
    // write your logic here
  }

  isCreateButtonDisabled(): boolean {
    // write your logic here
    return false;
  }

  handleCreateInvestment(): void {
    // write your logic here
  }

  handleUpdateInvestment(): void {
    // write your logic here
  }

  handleEditInvestment(id: number): void {
    // write your logic here
  }

  handleDeleteInvestment(id: number): void {
    // write your logic here
  }
}
