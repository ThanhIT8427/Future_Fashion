using Future_Fashion_API.entities;
using Future_Fashion_API.repository;
using Future_Fashion_API.repository.brands;

namespace Future_Fashion_API.services.brands
{
    public class BrandService : BaseService<int, TblBrands>, IBrandService
    {
        IBrandRepository _repository;
        public BrandService(IBrandRepository repository) : base(repository)
        {
            _repository = repository;   
        }
    }
}
