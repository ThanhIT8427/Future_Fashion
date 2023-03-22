using Future_Fashion_API.exceptions;
using Future_Fashion_API.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Future_Fashion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<PrimaryKey, Entitty> : ControllerBase
    {
        IBaseService<PrimaryKey, Entitty> _service;
        public BaseController(IBaseService<PrimaryKey, Entitty> baseService)
        {
            this._service = baseService;
        }


        /// <summary>
        /// Lấy toàn bộ bản ghi trong database
        /// </summary>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = this._service.Get();
                return Ok(data);
            }
            catch (AppException ex)
            {

                return HanldeExeption(ex);
            }
        }


        /// <summary>
        /// Lấy bản ghi theo khoá chính
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        [HttpGet("{id}")]
        public IActionResult Get(PrimaryKey id)
        {
            try
            {
                var employee = this._service.GetById(id);
                return Ok(employee);
            }
            catch (AppException ex)
            {
                return HanldeExeption(ex);


            }
        }


        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entitty"></param>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        [HttpPost]
        public IActionResult Insert([FromBody] Entitty entitty)
        {
            try
            {
                var res = this._service.Insert(entitty);
                return StatusCode(201, res);
            }
            catch (AppException ex)
            {

                return HanldeExeption(ex);
            }

        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="entitty"></param>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        [HttpPut]
        public IActionResult Update(Entitty entitty)
        {
            try
            {
                var res = this._service.Update(entitty);
                return Ok(res);
            }
            catch (AppException ex)
            {

                return HanldeExeption(ex);
            }
        }

        /// <summary>
        /// Xoá
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <author>DVANH(11/7/2022)</author>
        [HttpDelete]
        public IActionResult Delete(PrimaryKey id)
        {
            try
            {
                var res = this._service.Delete(id);
                return Ok(res);
            }
            catch (AppException ex)
            {

                return HanldeExeption(ex);
            }
        }

        /// <summary>
        /// Xử lý ngoại lệ
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        IActionResult HanldeExeption(Exception ex)
        {
            if (ex is AppException)
            {
                AppException e = (AppException)ex;
                var err = new
                {
                    devMsg = e.Message,
                    userMsg = e.validMessages[0],
                    data = e.validMessages
                };
                return StatusCode(400, err);
            }


            return StatusCode(500, new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xẩy ra, vui lòng liên hệ shop để được trợ giúp",
            });
        }

    }
}
