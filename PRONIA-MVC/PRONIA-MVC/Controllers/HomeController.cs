using Microsoft.AspNetCore.Mvc;
using PRONIA_DAL.Contexts;
using PRONIA_DAL.Models;

namespace PRONIA_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaDbContext _proniaDbContext;

        public HomeController(ProniaDbContext proniaDbContext)
        {
            _proniaDbContext = proniaDbContext;
        }

        public IActionResult Index()
        {
            List<SliderItem> sliderItems = _proniaDbContext.SliderItesms.ToList();



            return View(sliderItems);
        }
    }
}
