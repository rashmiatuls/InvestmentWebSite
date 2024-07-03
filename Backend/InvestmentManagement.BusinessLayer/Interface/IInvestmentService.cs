using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Interfaces
{
    public interface IInvestmentService
    {
        Task<Investment> CreateInvestment(Investment investment);
        Task<bool> DeleteInvestmentById(long id);
        List<Investment> GetAllInvestments();
        Task<Investment> GetInvestmentById(long id);
        Task<Investment> UpdateInvestment(InvestmentViewModel model);
    }
}
