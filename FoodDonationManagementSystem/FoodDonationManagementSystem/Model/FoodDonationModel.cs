using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Model
{
    public class FoodDonationModel
    {
        [Key]
        public int id { get; set; }
        public string DonorName { get; set; }
        public string DonationType { get; set; }
    }
}
