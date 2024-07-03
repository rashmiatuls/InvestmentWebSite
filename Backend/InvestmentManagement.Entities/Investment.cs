using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentManagement.Entities
{
    public class Investment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InvestmentId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string InvestmentName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal InitialInvestmentAmount { get; set; }

        [Required]
        public DateTime InvestmentStartDate { get; set; }

        public decimal? CurrentValue { get; set; }

        public int InvestorId { get; set; }
    }
}
