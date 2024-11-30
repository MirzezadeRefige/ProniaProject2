using Microsoft.AspNetCore.Mvc;
using PRONIA_BL.Services.Abstractions;
using PRONIA_DAL.Contexts;
using PRONIA_DAL.Models;

namespace PRONIA_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderItemService _sliderItemService;

        public HomeController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }

        public async Task<IActionResult> Index()
        {
            List<SliderItem> sliderItems = await _sliderItemService.GetAllAsync();
            return View(sliderItems);
        }
    }
}
