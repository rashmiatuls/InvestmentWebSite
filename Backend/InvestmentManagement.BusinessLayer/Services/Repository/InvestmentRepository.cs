using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.DataLayer;
using InvestmentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Services.Repository
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly InvestmentDbContext _dbContext;

        public InvestmentRepository(InvestmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Investment> CreateInvestment(Investment investment)
        {
            try
            {
                var result = await _dbContext.Investments.AddAsync(investment);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating investment.", ex);
            }
        }

        public async Task<bool> DeleteInvestmentById(long id)
        {
            try
            {
                var investment = await _dbContext.Investments.FindAsync(id);
                if (investment == null)
                    throw new KeyNotFoundException($"Investment with Id = {id} not found.");

                _dbContext.Investments.Remove(investment);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting investment.", ex);
            }
        }

        public List<Investment> GetAllInvestments()
        {
            try
            {
                return _dbContext.Investments.OrderByDescending(x => x.InvestmentId).Take(10).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving investments.", ex);
            }
        }

        public async Task<Investment> GetInvestmentById(long id)
        {
            try
            {
                var investment = await _dbContext.Investments.FindAsync(id);
                if (investment == null)
                    throw new KeyNotFoundException($"Investment with Id = {id} not found.");

                return investment;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving investment.", ex);
            }
        }

        public async Task<Investment> UpdateInvestment(InvestmentViewModel model)
        {
            try
            {
                var investment = await _dbContext.Investments.FindAsync(model.InvestmentId);
                if (investment == null)
                    throw new KeyNotFoundException($"Investment with Id = {model.InvestmentId} not found.");

                investment.InvestmentName = model.InvestmentName;
                investment.InitialInvestmentAmount = model.InitialInvestmentAmount;
                investment.InvestmentStartDate = model.InvestmentStartDate;
                investment.CurrentValue = model.CurrentValue;

                _dbContext.Investments.Update(investment);
                await _dbContext.SaveChangesAsync();
                return investment;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating investment.", ex);
            }
        }
    }
}
