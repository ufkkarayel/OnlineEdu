using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.App.DTOs.BlogCategoryDtos;
using OnlineEdu.App.DTOs.BlogDtos;
using OnlineEdu.App.Helpers;
using OnlineEdu.App.DTOs.BlogDtos;

namespace OnlineEdu.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task CategoryDropDown()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            List<SelectListItem> categories=(from x in categoryList
                                             select new SelectListItem
                                             {
                                                 Text=x.Name,
                                                 Value=x.BlogCategoryID.ToString()
                                             }).ToList();
            ViewBag.categories = categories;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync($"blogs/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
           await CategoryDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _client.PostAsJsonAsync("blogs",createBlogDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await CategoryDropDown();
            var value = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/"+id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _client.PutAsJsonAsync("blogs/",updateBlogDto);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
