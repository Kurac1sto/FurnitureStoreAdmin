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
        public async Task<List<Furniture>> GetAllItemsAsync()
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
        public async Task<List<Furniture>> GetItemsAsync(int pageSize, int pageNumber)
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
        public async Task<int> CountAsync()
            => await _context.Furniture.CountAsync();
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (!disposing || _context == null) return;

            _context.Dispose();
            _context = null;
        }
    }
}