using System.Collections.Generic;
using System.Threading.Tasks;
using Abstraction.Interfaces;
using FurnitureStoreAdmin.DAL.Entities;
using FurnitureStoreAdmin.DAL.Repositories;

namespace FurnitureStoreAdmin.BLL.Services
{
    /// <summary>
    /// Сервис для работы с базой данных
    /// </summary>
    public class FurnitureService
    {
        private readonly IRepository<Furniture> _furnitureRepository;

        public FurnitureService()
        {
            _furnitureRepository = new FurnitureRepository();
        }

        /// <summary>
        ///  Получение списка продуктов на страницу
        /// </summary>
        /// <param name="pageSize">Количество записей на страницу</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<List<Furniture>> GetItems(int pageSize, int pageNumber)
        {
            var furniture = await _furnitureRepository.GetItems(pageSize, pageNumber);

            return furniture;
        }

        /// <summary>
        /// Количество записей в бд
        /// </summary>
        /// <returns></returns>
        public async Task<int> Count()
            => await _furnitureRepository.Count();
    }
}