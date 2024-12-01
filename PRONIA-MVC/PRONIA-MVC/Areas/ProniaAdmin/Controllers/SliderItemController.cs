using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PRONIA_BL.Services.Abstractions;
using PRONIA_DAL.Migrations;
using PRONIA_DAL.Models;
using PRONIA_MVC.Areas.ProniaAdmin.ViewModels;

namespace PRONIA_MVC.Areas.ProniaAdmin.Controllers
{
    [Area("ProniaAdmin")]
    public class SliderItemController : Controller
    {
        private readonly ISliderItemService _sliderItemService;

        public SliderItemController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }

        public async Task<IActionResult> Index()
        {
            List<SliderItem> sliderItems = await _sliderItemService.GetAllAsync();
            return View(sliderItems);
        }
        public async Task<IActionResult> Info(int id)
        {

            SliderItem sliderItem = await _sliderItemService.GetByIdAsync(id);
            return View(sliderItem);
        }
        //public async Task<IActionResult> RemoveAsync(int id)
        //{
        //    SliderItem sliderItem = await _sliderItemService.SoftDeleteSliderItemAsync(id);
        //    return View(sliderItem);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderItemCreateVM sliderItemCreateVM)
        {
            if(!ModelState.IsValid)
            {
                return View(sliderItemCreateVM);
            }
            SliderItem sliderItem = new SliderItem()
            {
            Title=sliderItemCreateVM.Title,
            ShortDescription=sliderItemCreateVM.ShortDecription,
            Offer=sliderItemCreateVM.Offer, 
            ImgPath=sliderItemCreateVM.ImgPath, 
            CreatedDate=DateTime.Now
            };
          await  _sliderItemService.CreateSliderItemAsync(sliderItem);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SliderItem sliderItem = await _sliderItemService.GetByIdAsync(id);
            return View(sliderItem);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateSliderItemAsync(int id,SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderItem);
            }

          await  _sliderItemService.UpdateSliderItemAsync(id, sliderItem);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult>  SoftDelete(int id) 
        {
         SliderItem sliderItem=  await _sliderItemService.GetByIdAsync(id);
            return View(sliderItem);
        }
        [HttpPost]
        [ActionName("softDelete")]
        public async Task<IActionResult> SoftDeletePost(int id)
        {
            await _sliderItemService.SoftDeleteSliderItemAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
