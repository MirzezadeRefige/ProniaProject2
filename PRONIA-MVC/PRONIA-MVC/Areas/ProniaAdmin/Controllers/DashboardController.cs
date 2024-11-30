using Microsoft.AspNetCore.Mvc;
using PRONIA_BL.Services.Abstractions;
using PRONIA_DAL.Models;

namespace PRONIA_MVC.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class DashboardController : Controller
    {
        private readonly ISliderItemService _sliderItemService;

        public DashboardController(ISliderItemService sliderItemService)
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
