using Future_Fashion_API.exceptions;
using Future_Fashion_API.repository;

namespace Future_Fashion_API.services
{
    public class BaseService<PrimaryKey, Entity> : IBaseService<PrimaryKey, Entity>
    {
        IBaseRepository<PrimaryKey, Entity> _repository;

        #region Constructor
        public BaseService(IBaseRepository<PrimaryKey, Entity> repository)
        {
            _repository = repository;
        }

       
        #endregion


        #region Methods
        /// <summary>
        /// Validate dữ liệu lúc thêm mới
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true nếu đầu và hợp lệ, false nếu đầu vào không hợp lệ!</returns>
        /// <author>DVANH(29/06/222)</author>
        public virtual dynamic ValidationInsert(Entity obj)
        {
            return new
            {
                res = true,
                data = new List<string>(),
            };
        }


        /// <summary>
        /// Validate dữ liệu lúc cập nhật
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true nếu đầu và hợp lệ, false nếu đầu vào không hợp lệ!</returns>
        /// <author>DVANH(29/06/222)</author>
        public virtual dynamic ValidationUpdate(Entity obj)
        {
            return new
            {
                res = true,
                data = new List<string>(),
            };
        }


        /// <summary>
        /// Xoá bản ghi
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns>số lượng bản ghi bị xoá khỏi database</returns>
        /// <author>DVANH(29/06/2022)</author>
        public int Delete(PrimaryKey id)
        {
            var res = _repository.Delete(id);
            return res;
        }

        /// <summary>
        /// Lấy tất  cả các bản ghi
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        /// <author>DVANH(29/06/2022)</author>
        public IEnumerable<Entity> Get()
        {
            var entitys = _repository.Get();
            return entitys;

        }

        /// <summary>
        /// Lấy bản ghi theo khoá chính
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns></returns>
        /// <author>DVANH(29/06/2022)</author>
        public Entity GetById(PrimaryKey id)
        {
            var entity = _repository.GetById(id);
            return entity;
        }


        /// <summary>
        /// Chèn thêm bản ghi vào bảng
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 nêu chèn thành công, 0 nếu  chèn thất bại</returns>
        /// <author>DVANH(29/06/2022)</author>
        public int Insert(Entity obj)
        {
            //validate dữ liệu

            var valid = ValidationInsert(obj);

            if (!valid.res)
            {
                throw new AppException((List<string>)valid.data);
            }


            var res = _repository.Insert(obj);
            return res;
        }

        /// <summary>
        /// Cập nhật bản ghi 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 nếu cập nhật thành công, 0 nếu cập nhật thất bại</returns>
        /// <author>DVANH(29/06/2022)</author>
        public int Update(Entity obj)
        {
            //Validate dữ liệu
            var valid = ValidationUpdate(obj);

            if (!valid.res)
            {
                throw new AppException((List<string>)valid.data);
            }

            var res = _repository.Update(obj);
            return res;
        }
        #endregion
    }
}
