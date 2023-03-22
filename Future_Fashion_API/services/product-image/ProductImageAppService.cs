using Future_Fashion_API.entities;
using Future_Fashion_API.repository;

namespace Future_Fashion_API.services
{
    public class ProductImageAppService : BaseService<int, TblProductImages>, IProductImageAppService
    {
        private readonly IProductImageRepository _repository;
        public ProductImageAppService(IProductImageRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
