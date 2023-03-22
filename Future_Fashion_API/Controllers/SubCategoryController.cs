using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Future_Fashion_API.entities;
using Future_Fashion_API.services;
using Future_Fashion_API.services.subcategory;

namespace Future_Fashion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : BaseController<int, TblSubCategory>
    {
        ISubCategoryService service;
        public SubCategoryController(ISubCategoryService baseService) : base(baseService)
        {
            service = baseService;
        }
    }
}
