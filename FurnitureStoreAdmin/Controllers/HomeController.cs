using System.Threading.Tasks;
using System.Web.Mvc;
using FurnitureStoreAdmin.BLL.Models;
using FurnitureStoreAdmin.BLL.Services;
using FurnitureStoreAdmin.Models;

namespace FurnitureStoreAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly FurnitureService _furnitureService;

        public HomeController()
        {
            _furnitureService = new FurnitureService();
        }
        
        public HomeController(FurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }
        
        public async Task<ActionResult> Index(int pageSize = 20, int pageNumber = 1)
        {
            var items = await _furnitureService.GetItems(pageSize, pageNumber);
            var totalItems = await _furnitureService.Count();

            var pageInfo = new PageInfo()
            {
                PageSize = pageSize,
                PageNumber = pageNumber,
                TotalItems = totalItems
            };
            
            var model = new FurnitureModel()
            {
                Items = items,
                Info = pageInfo
            };

            return View(model);
        }
    }
}