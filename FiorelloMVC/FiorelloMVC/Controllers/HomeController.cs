
using FiorelloMVC.Services;
using FiorelloMVC.Services.Interfaces;
using FiorelloMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FiorelloMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
       private readonly IBlogService _blogService;
        private readonly IExpertService _expertService;

        public HomeController(ISliderService sliderService,IBlogService blogService,IExpertService expertService)
        {
            _blogService = blogService;
            _sliderService = sliderService;
            _expertService = expertService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new()
            {
              Sliders=await _sliderService.GetAllAsync(),
              SliderInfo=await _sliderService.GetSliderInfoAsync(),
              Blogs=await _blogService.GetAllAsync(),
              Experts=await  _expertService.GetAllAsync(),

            };
            return View(model);
        }

      
     
    }
}
