using FoodDonationManagementSystem.Core.Interface;
using FoodDonationManagementSystem.DataAccess;
using FoodDonationManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Core.ImplementInterface
{
    public class FoodDonation : IFoodDonation
    {
        private readonly DonationDbContext context;
        public FoodDonation(DonationDbContext context)
        {
            this.context = context;
        }
        public List<FoodDonationModel> Get()
        {
            return context.studentModels.ToList();
        }

        public FoodDonationModel Post(FoodDonationModel foodDonationModel)
        {
            context.studentModels.AddAsync(foodDonationModel);
            context.SaveChangesAsync();
            return foodDonationModel;
        }
    }
}
