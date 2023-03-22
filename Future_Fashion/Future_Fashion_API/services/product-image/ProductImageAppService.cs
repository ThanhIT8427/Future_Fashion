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
        public override dynamic ValidationInsert(TblProductImages obj)
        {
            var path = $@"{Directory.GetParent(Directory.GetCurrentDirectory())}\MyEShoppingWebsite\Images\ProductImages\{obj.Pid}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            obj.Name = obj.Name + Guid.NewGuid().ToString();
            obj.Extention = "." + obj.ImageBase64.Split(',')[0].Split('/')[1].Split(';')[0];
            path = $@"{path}\{obj.Name}{obj.Extention}";
            // Convert Base64 string to bytes
            byte[] imageBytes = Convert.FromBase64String(obj.ImageBase64.Split(',')[1]);
            File.WriteAllBytes(path, imageBytes);
            return base.ValidationInsert(obj);
        }
    }
}
