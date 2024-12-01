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

        public IActionResult Index(int? id)
        {
          return View(id);
        }
    }
}
