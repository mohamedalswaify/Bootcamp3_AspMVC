using Bootcamp3_AspMVC.Dtos;
using Bootcamp3_AspMVC.Interfaces.IServices;
using Bootcamp3_AspMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp3_Asp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GatAll()
        {
            try
            {
                //int a = 10;
                //var x = a / 0; // to test exception handling
                IEnumerable<Category> categories = _categoryService.GetAll();
                if (categories == null || !categories.Any())
                {
                    return NotFound("لا توجد فئات متاحة"); //204
                }
                return Ok(categories);

            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

        }


        [HttpGet("{uid}")]
        public ActionResult<Category> GetByUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    return BadRequest("Uid is required.");

                var category = _categoryService.GetByUid(uid);
                if (category == null)
                    return NotFound(); // 404

                return Ok(category); // 200

            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

        }







        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] CategoryDto category)
        {
            try
            {
                if (category == null || string.IsNullOrWhiteSpace(category.Name))
                    return BadRequest("بيانات الفئة فارغه ");
                if (!ModelState.IsValid)
                    return BadRequest("بيانات الفئة غير صحيحة");

                var newCategory = new Category
                {
                    Name = category.Name,
                    Description = category.Description
                };


                _categoryService.Create(newCategory);

                return Ok("تم انشاء الفئة بنجاح");
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

        }

            // PUT: api/categories/{uid}
            [HttpPut("{uid}")]
            public IActionResult Update(string uid, [FromBody] CategoryUpdateDto category)
            {
                if (string.IsNullOrWhiteSpace(uid))
                    return BadRequest("Uid is required.");

                if (category == null)
                    return BadRequest("Category payload is required.");

                if (!ModelState.IsValid)
                    return ValidationProblem(ModelState);

                var exists = _categoryService.GetByUid(uid);
                if (exists == null)
                    return NotFound(); // 404

                // نضمن التحديث على نفس الـUid

            var newCategory = new Category
            {
                Uid = category.Uid,
                Name = category.Name,
                Description = category.Description
            };



            _categoryService.Update(uid, newCategory);
                return  Ok("تم تحديث الفئة بنجاح");
        }



        // DELETE: api/categories/{uid}
        [HttpDelete("{uid}")]
        public IActionResult Delete(string uid)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return BadRequest("Uid is required.");

            var exists = _categoryService.GetByUid(uid);
            if (exists == null)
                return NotFound(); // 404

            _categoryService.DeleteByUid(uid);
            return Ok("تم حذف الفئة بنجاح"); // 204
        }






    }



    }

