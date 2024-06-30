import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Investment } from '../models/investment-planning.model';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {
  private apiUrl = '';

  constructor(private http: HttpClient) { }

  getAllInvestments(): any {
    // write your logic here
    return null;
  }

  getInvestmentById(id: number): any {
    // write your logic here
    return null;
  }

  createInvestment(investment: Investment): any {
    // write your logic here
    return null;
  }

  updateInvestment(investment: Investment): any {
    // write your logic here
    return null;
  }

  deleteInvestment(id: number): any {
    // write your logic here
    return null;
  }
}
