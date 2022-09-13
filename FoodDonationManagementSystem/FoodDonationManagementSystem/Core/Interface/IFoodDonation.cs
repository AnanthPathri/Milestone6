using FoodDonationManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Core.Interface
{
    public interface IFoodDonation
    {
        List<FoodDonationModel> Get();
        FoodDonationModel Post(FoodDonationModel foodDonationModel);
    }
}
