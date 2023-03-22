using Future_Fashion_API.entities;
using Future_Fashion_API.repository;
using Future_Fashion_API.repository.categories;

namespace Future_Fashion_API.services.cateories
{
    public class CategoryService : BaseService<int, TblCategory>, ICategoryService
    {
        ICategoryRespository _respository;
        public CategoryService(ICategoryRespository repository) : base(repository)
        {
            _respository = repository;
        }
    }
}
