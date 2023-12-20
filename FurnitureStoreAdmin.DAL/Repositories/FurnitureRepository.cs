using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using FurnitureStoreAdmin.DAL.Contexts;
using FurnitureStoreAdmin.DAL.Entities;

namespace FurnitureStoreAdmin.DAL.Repositories
{
    /// <summary>
    /// Репозиторий для работы с бд
    /// </summary>
    public class FurnitureRepository : IRepository<Furniture>, IDisposable
    {
        private ApplicationContext _context = new ApplicationContext();

        /// <summary>
        /// Получение всех записей из бд
        /// </summary>
        /// <returns></returns>
        public async Task<List<Furniture>> GetAllItems()
        {
            var furniture = await _context.Furniture.ToListAsync();
            
            return furniture;
        }

        /// <summary>
        /// Получение записей из бд на страницу
        /// </summary>
        /// <param name="pageSize">Количество записей на страницу</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<List<Furniture>> GetItems(int pageSize, int pageNumber)
        {
            var furnitureIQuer = _context.Furniture as IQueryable<Furniture>;
            var furniture = await furnitureIQuer.OrderBy(item => item.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return furniture;
        }

        /// <summary>
        /// Количество записей в бд
        /// </summary>
        /// <returns></returns>
        public async Task<int> Count()
            => _context.Furniture.Count();

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}