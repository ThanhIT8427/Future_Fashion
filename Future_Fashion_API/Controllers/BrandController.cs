using Future_Fashion_API.entities;
using Future_Fashion_API.services;
using Future_Fashion_API.services.brands;

namespace Future_Fashion_API.Controllers
{
    public class BrandController : BaseController<int, TblBrands>
    {
        IBrandService brandService;
        public BrandController(IBrandService baseService) : base(baseService)
        {
            brandService = baseService;
        }
    }
}
