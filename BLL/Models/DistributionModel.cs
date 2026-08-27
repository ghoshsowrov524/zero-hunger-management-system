using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class DistributionModel
    {
        public int Id { get; set; }

        [Range(1, 10,
            ErrorMessage = "Valid Collect Request ID is required")]
        public int CollectRequestId { get; set; }

        [Range(1, 10,
            ErrorMessage = "Valid Employee ID is required")]
        public int EmployeeId { get; set; }

        public DateTime DistributionDate { get; set; }

        [Required(ErrorMessage = "Distribution location is required")]
        [StringLength(200,
            ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; } = null!;

        [Range(1, 100000,
            ErrorMessage = "Beneficiary count must be greater than 0")]
        public int BeneficiaryCount { get; set; }

        [StringLength(500,
            ErrorMessage = "Remarks cannot exceed 500 characters")]
        public string Remarks { get; set; } = null!;
    }
}