using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class FoodItemModel
    {
        public int Id { get; set; }

        [Range(1, 10,
            ErrorMessage = "Valid Collect Request ID is required")]
        public int CollectRequestId { get; set; }

        [Required(ErrorMessage = "Food name is required")]
        [StringLength(100, MinimumLength = 2,
            ErrorMessage = "Food name must be between 2 and 100 characters")]
        public string FoodName { get; set; } = null!;

        [Range(0.1, 100000,
            ErrorMessage = "Quantity must be greater than 0")]
        public decimal Qty { get; set; }

        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; } = null!;

        [StringLength(500,
            ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = null!;
    }
}