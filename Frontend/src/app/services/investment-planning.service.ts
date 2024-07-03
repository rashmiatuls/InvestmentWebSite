import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Investment } from '../models/investment-planning.model';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {
  private baseUrl = 'http://localhost:5000'; // Ensure this is the correct base URL for your API

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  // Create Investment
  createInvestment(investment: Investment): Observable<any> {
    const url = `${this.baseUrl}/create-investment`;
    return this.http.post(url, investment, this.httpOptions);
  }

  // Update Investment
  updateInvestment(investment: Investment): Observable<any> {
    const url = `${this.baseUrl}/update-investment`;
    return this.http.put(url, investment, this.httpOptions);
  }


  getAllInvestments(): Observable<Investment[]> {
    return this.http.get<Investment[]>(`${this.baseUrl}/get-all-investments`).pipe(
      catchError(this.handleError)
    );
  }


  // Delete Investment
  deleteInvestment(id: number): Observable<any> {
    const url = `${this.baseUrl}/delete-investment?id=${id}`;
    return this.http.delete(url, this.httpOptions);
  }
  
  getInvestmentById(id: number): Observable<Investment> {
    return this.http.get<Investment>(`${this.baseUrl}/get-investment-by-id/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
