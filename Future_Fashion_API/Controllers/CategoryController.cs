using Future_Fashion_API.entities;
using Future_Fashion_API.services;
using Future_Fashion_API.services.cateories;

namespace Future_Fashion_API.Controllers
{
    public class CategoryController : BaseController<int, TblCategory>
    {
        ICategoryService service;
        public CategoryController(ICategoryService baseService) : base(baseService)
        {
            service = baseService;
        }
    }
}
