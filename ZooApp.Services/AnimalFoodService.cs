using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalFoodService
    {
        public List<ViewFoodTotal> GetViewFoodTotals()
        {
            ZooContext db = new ZooContext();
            var animalFoods = db.AnimalFoods.ToList();
            List<ViewFoodTotal> aViewFoodTotals = new List<ViewFoodTotal>();
            foreach (AnimalFood animalFood in animalFoods)
            {
                ViewFoodTotal aViewFoodTotal = new ViewFoodTotal(animalFood);
                aViewFoodTotals.Add(aViewFoodTotal);
            }
            List<ViewFoodTotal> result = new List<ViewFoodTotal>();
            var groupBy = aViewFoodTotals.GroupBy(x => x.FoodName);
            foreach (IGrouping<string, ViewFoodTotal> grouping in groupBy)
            {
                double totalPrice = grouping.Sum(x => x.TotalPrice);
                double totalQuantity = grouping.Sum(c => c.TotalQuantity);
                ViewFoodTotal aViewFoodTotal = new ViewFoodTotal()
                {
                    FoodName = grouping.Key,
                    FoodPrice = grouping.First().FoodPrice,
                    TotalQuantity = totalQuantity,
                    TotalPrice = totalPrice
                };
                result.Add(aViewFoodTotal);
            }
            return result;
        }
    }
}
