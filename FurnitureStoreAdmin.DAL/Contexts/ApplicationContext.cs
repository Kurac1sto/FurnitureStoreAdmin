using System.Data.Entity;
using FurnitureStoreAdmin.DAL.Entities;
using FurnitureStoreAdmin.DAL.Initializers;

namespace FurnitureStoreAdmin.DAL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Furniture> Furniture { get; set; }

        // Стартовая инициализация бд данными
        static ApplicationContext()
            => Database.SetInitializer<ApplicationContext>(new FurnitureInitializer());
        
        public ApplicationContext() : base("DefaultConnection")
        {
            
        }
    }
}