using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.Services.Repository;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<Investment> CreateInvestment(Investment investment)
        {
            ValidateInvestment(investment);
            return await _investmentRepository.CreateInvestment(investment);
        }

        public async Task<bool> DeleteInvestmentById(long id)
        {
            var investment = await _investmentRepository.GetInvestmentById(id);
            if (investment == null)
                throw new KeyNotFoundException($"Investment with Id = {id} not found.");

            return await _investmentRepository.DeleteInvestmentById(id);
        }

        public List<Investment> GetAllInvestments()
        {
            return _investmentRepository.GetAllInvestments();
        }

        public async Task<Investment> GetInvestmentById(long id)
        {
            var investment = await _investmentRepository.GetInvestmentById(id);
            if (investment == null)
                throw new KeyNotFoundException($"Investment with Id = {id} not found.");

            return investment;
        }

        public async Task<Investment> UpdateInvestment(InvestmentViewModel model)
        {
            var investment = await _investmentRepository.GetInvestmentById(model.InvestmentId);
            if (investment == null)
                throw new KeyNotFoundException($"Investment with Id = {model.InvestmentId} not found.");

            return await _investmentRepository.UpdateInvestment(model);
        }

        private void ValidateInvestment(Investment investment)
        {
            if (investment == null)
                throw new System.ArgumentNullException(nameof(investment));

            if (string.IsNullOrWhiteSpace(investment.InvestmentName) || investment.InvestmentName.Length < 3 || investment.InvestmentName.Length > 100)
                throw new ValidationException("InvestmentName must be between 3 and 100 characters.");

            if (investment.InitialInvestmentAmount <= 0)
                throw new ValidationException("InitialInvestmentAmount must be greater than 0.");

            if (investment.InvestmentStartDate == default)
                throw new ValidationException("InvestmentStartDate is required.");
        }
    }
}
