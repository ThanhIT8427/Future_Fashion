using Dapper;
using System.Data.SqlClient;
using System.Reflection;

namespace Future_Fashion_API.repository
{
    public class BaseRepository<PrimaryKey, Entity> : IBaseRepository<PrimaryKey, Entity>
    {
        protected string _connectionSring;
        protected SqlConnection _sqlConnection;
        public BaseRepository()
        {
          
            //_connectionSring = $"server={resource.server};uid={resource.uid};pwd={resource.pwd};database={resource.database}";
            _connectionSring = @"server=.; database=SHOP2; Integrated Security=true";
            _connectionSring = @"Data Source=LAPTOP-QUKATC0N\SQLEXPRESS;Initial Catalog=SHOP2;Integrated Security=True";
        }
        #region Methods
        /// <summary>
        /// Xoá bản  ghi theo khoá chính
        /// </summary>
        /// <param name="id">khoá chín</param>
        /// <returns>1 nếu xoá thành công, 0 nếu xoá thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        public int Delete(PrimaryKey id)
        {
            using (_sqlConnection = new SqlConnection(_connectionSring))
            {
                var sql = $"Proc_Delete{typeof(Entity).Name}";
                var parms = new DynamicParameters();
                parms.Add("ID", id);

                var res = this._sqlConnection.Execute(sql, parms, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }

        }

        /// <summary>
        /// Lấy toàn bộ bản ghi trong database
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        /// <author>DVANH(11/7/2022)</author>
        public virtual IEnumerable<Entity> Get()
        {
            using (_sqlConnection = new SqlConnection(_connectionSring))
            {

                var sql = $"SELECT  * FROM {typeof(Entity).Name}";
      
                var entitys = this._sqlConnection.Query<Entity>(sql);
                return entitys;
            }

        }

        /// <summary>
        /// Lấy bản ghi theo khoá chính
        /// </summary>
        /// <param name="id">khoá chính</param>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        public Entity GetById(PrimaryKey id)
        {
            using (_sqlConnection = new SqlConnection(_connectionSring))
            {
                var sql = $"SELECT  * FROM {typeof(Entity).Name} WHERE ID = '{id}'";
                var bankAccount = this._sqlConnection.QuerySingleOrDefault<Entity>(sql);
                return bankAccount;
            }
        }

        /// <summary>
        /// Chèn bản ghi vào database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 nếu chèn thành công, 0 nếu chèn thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        public int Insert(Entity obj)
        {
            using (_sqlConnection = new SqlConnection(_connectionSring))
            {
                // Lấy kiểu của đối tượng
                Type type = obj.GetType();

                // Lấy danh sách các thuộc tính của đối tượng
                PropertyInfo[] properties = type.GetProperties();

                var attr = $"@{properties[1].Name}";
                var attr2 = properties[1].Name;
                var idName = "";
               for(int i = 0; i < properties.Length; i++)
                {
                    if (i > 1)
                    {
                        var propertyIgnore = properties[i].GetCustomAttributes(typeof(attributes.PropertyIgnore), true);
                        if (propertyIgnore.Length == 0)
                        {
                            attr = $"{attr},@{properties[i].Name}";
                            attr2 = $"{attr2},{properties[i].Name}";
                        }

                    }

                    var primarykey = properties[i].GetCustomAttributes(typeof(attributes.PrimaryKey), true);
                    if (primarykey.Length > 0)
                    {
                        idName = properties[i].Name;
                    }
                }
                
              

                var sql = $"INSERT INTO  {typeof(Entity).Name} ({attr2}) VALUES ({attr})";
                 this._sqlConnection.Execute(sql, obj);
                var res = _sqlConnection.QueryFirstOrDefault<int>($"SELECT MAX({idName}) FROM {typeof(Entity).Name}");
                return res;
            }
        }

        /// <summary>
        /// Cập nhât bản ghi
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>1 nếu cập nhật thành công, 0 nếu cập nhật thất bại</returns>
        /// <author>DVANH(11/7/2022)</author>
        public int Update(Entity obj)
        {
            using (_sqlConnection = new SqlConnection(_connectionSring))
            {
                Type type = obj.GetType();

                // Lấy danh sách các thuộc tính của đối tượng ma khac id
                var properties = type.GetProperties().ToList().FindAll(x => x.Name != "ID").ToList();

                var attr = $"{properties[0].Name}=@{properties[0].Name}";

                for (int i = 1; i < properties.Count; i++)
                {
                    attr = $"{attr},{properties[i].Name}=@{properties[i].Name}";
                }

                var sql = $"UPDATE {typeof(Entity).Name} SET {attr} WHERE ID=@ID";
                var res = this._sqlConnection.Execute(sql, obj, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }

        }
        #endregion

    }
}
