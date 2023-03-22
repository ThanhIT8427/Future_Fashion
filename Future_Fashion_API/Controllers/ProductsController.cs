using Future_Fashion_API.entities;
using Future_Fashion_API.services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;

namespace Future_Fashion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<int,TblProducts>
    {
        private IProductAppService _productAppService;

        public ProductsController(IProductAppService baseService) : base(baseService)
        {
            _productAppService = baseService;
        }
    }
}
