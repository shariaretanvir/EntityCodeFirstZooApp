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
    public class AnimalService
    {
        ZooContext adbContext = new ZooContext();
        public List<ViewAnimal> GetAnimals()
        {
            
            List<Animal> animals = adbContext.Animals.ToList();
            List<ViewAnimal> listofViewAnimals = new List<ViewAnimal>();
            foreach (Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id = animal.Id,
                    Quantity = animal.Quantity,
                    Origin = animal.Origin,
                    Food = animal.Food,
                    Name = animal.Name
                };
                listofViewAnimals.Add(viewAnimal);
            }
            return listofViewAnimals;
        }

        public ViewAnimal GetAnimal(int id)
        {
            Animal animal = adbContext.Animals.Find(id);
            return new ViewAnimal()
            {
                Food = animal.Food,
                Quantity = animal.Quantity,
                Origin = animal.Origin,
                Name = animal.Name,
                Id = animal.Id
            };
        }

        public bool Save(Animal animal)
        {
            Animal add = adbContext.Animals.Add(animal);
            adbContext.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            adbContext.Entry(animal).State = EntityState.Modified;
            adbContext.SaveChanges();
            return true;
        }

        public bool Delete(Animal animal)
        {
            Animal aaAnimal = adbContext.Animals.Find(animal.Id);
            adbContext.Animals.Remove(aaAnimal);
            adbContext.SaveChanges();
            return true;
        }

        public Animal GetDbAnimal(int id)
        {
            return adbContext.Animals.Find(id);
        }
    }
}
