
  export interface Investment {
    investmentId: number;
    investmentName: string;
    initialInvestmentAmount: number;
    investmentStartDate: Date;
    currentValue?: number;
    investorId: number;
  }
  
  
  
  export interface InvestmentViewModel {
    investmentId: number;
    investmentName: string;
    initialInvestmentAmount: number;
    investmentStartDate: Date;
    currentValue?: number;
    investorId: number;
  }
  