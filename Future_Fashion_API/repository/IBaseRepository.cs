namespace Future_Fashion_API.repository
{
    public interface IBaseRepository<PrimaryKey, Entity>
    {
        /// <summary>
        /// Lấy toàn bộ bản ghi trong cơ sở dữ liệu
        /// </summary>
        /// <returns>Toàn bộ bản ghi trong CSDL</returns>
        /// <author>DVANH(11/7/2022)</author>
        IEnumerable<Entity> Get();

        /// <summary>
        /// Lấy bản ghi theo khoá chính
        /// </summary>
        /// <param name="id">khoá chính</param>
        /// <returns>Bản ghi</returns>
        /// <author>DVANH(11/7/2022)</author>
        Entity GetById(PrimaryKey id);

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="obj">Bản ghi mới</param>
        /// <returns>1 nếu cập nhật thành công, 0 nếu cập nhật thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        int Insert(Entity obj);

        /// <summary>
        /// Cập nhật phòng ban
        /// </summary>
        /// <param name="obj">Bản ghi mới</param>
        /// <returns>1 nếu cập nhật thành công 0 nếu cập nhật thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        int Update(Entity obj);

        /// <summary>
        /// Xoá bản ghi theo khoá chính
        /// </summary>
        /// <param name="id">Khoá chính</param>
        /// <returns>1 Nếu xoá thành công , 0 nếu xoá thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        int Delete(PrimaryKey id);
    }
}
