using Future_Fashion_API.entities;
using Future_Fashion_API.repository;

namespace Future_Fashion_API.services;

public class ProductAppService : BaseService<int, TblProducts>, IProductAppService
{
    private readonly IProductRepository _repository;
    public ProductAppService(IProductRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
