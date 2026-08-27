using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class CollectRequestModel
    {
        public int Id { get; set; }

        [Range(1, 10 ,
            ErrorMessage = "Valid Restaurant ID is required")]
        public int RestaurantId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Maximum preserve time is required")]
        public DateTime MaximumPreserveTime { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = null!;

        public DateTime? CollectedDate { get; set; }

        public DateTime? CompletedDate { get; set; }
    }
}