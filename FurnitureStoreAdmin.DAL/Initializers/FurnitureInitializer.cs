using System;
using System.Collections.Generic;
using System.Data.Entity;
using FurnitureStoreAdmin.DAL.Contexts;
using FurnitureStoreAdmin.DAL.Entities;

namespace FurnitureStoreAdmin.DAL.Initializers
{
    /// <summary>
    /// Стартовые данные для бд
    /// </summary>
    public class FurnitureInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            var rand = new Random();
            var map = new Dictionary<int, string>()
            {
                { 1, "Стол" },
                { 2, "Стул" },
                { 3, "Диван" },
                { 4, "Кровать" },
                { 5, "Куханная мебель" },
                { 6, "Офисная мебель" },
                { 7, "Шкафы-купе" },
            };
            
            var furniture = new List<Furniture>();
            
            for (var i = 0; i < 100000; i++)
            {
                var index = rand.Next(1, 8);
                
                furniture.Add(new Furniture()
                {
                    Name = map[index],
                    Description = $"Описание для {map[index]}"
                });    
            }

            db.Furniture.AddRange(furniture);
            db.SaveChanges();
        }
    }
}