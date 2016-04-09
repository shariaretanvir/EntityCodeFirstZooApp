using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext adbContext = new ZooContext();
        public List<ViewFood> GetAll()
        {

            var list = adbContext.Foods.ToList();
            List<ViewFood> listofViewFoods = new List<ViewFood>();
            foreach (var l in list)
            {
                var viewFood = new ViewFood(l);
                listofViewFoods.Add(viewFood);
            }
            return listofViewFoods;
        }

        public ViewFood Get(int id)
        {
            var food = adbContext.Foods.Find(id);
            return new ViewFood(food);
        }

        public bool Save(Food food)
        {
            Food add = adbContext.Foods.Add(food);
            adbContext.SaveChanges();
            return true;
        }

        public bool Update(Food food)
        {
            adbContext.Entry(food).State = EntityState.Modified;
            adbContext.SaveChanges();
            return true;
        }

        public bool Delete(Food food)
        {
            Food entity = adbContext.Foods.Find(food.Id);
            adbContext.Foods.Remove(entity);
            adbContext.SaveChanges();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return adbContext.Foods.Find(id);
        }
    }
}
