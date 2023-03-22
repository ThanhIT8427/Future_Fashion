using Future_Fashion_API.entities;
using Future_Fashion_API.repository;
using Future_Fashion_API.repository.subcategories;

namespace Future_Fashion_API.services.subcategory
{
    public class SubCategoryService : BaseService<int, TblSubCategory>, ISubCategoryService
    {
        ISubCategoriesRepository _repository;
        public SubCategoryService(ISubCategoriesRepository repository) : base(repository)
        {
            _repository = repository;   
        }
    }
}
