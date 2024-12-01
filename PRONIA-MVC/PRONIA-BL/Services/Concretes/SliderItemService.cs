using Microsoft.EntityFrameworkCore;
using PRONIA_BL.Services.Abstractions;
using PRONIA_DAL.Contexts;
using PRONIA_DAL.Models;

namespace PRONIA_BL.Services.Concretes
{
    public class SliderItemService : ISliderItemService
    {
        private readonly ProniaDbContext _context;

        public SliderItemService(ProniaDbContext context)
        {
            _context = context;
        }
        public async Task<List<SliderItem>> GetAllAsync()
        {
            List<SliderItem> sliderItems = await _context.SliderItem.ToListAsync();
            return sliderItems;
        }
        public async Task<SliderItem> GetByIdAsync(int id)
        {
            SliderItem sliderItem = await _context.SliderItem.FirstOrDefaultAsync(x => x.Id == id);
            if (sliderItem == null) {
                throw new Exception("not found.");
                    }
            return sliderItem;

        }

      
        public async Task SoftDeleteSliderItemAsync(int id)
        {
            SliderItem sliderItem = await _context.SliderItem.SingleOrDefaultAsync(x => x.Id == id);
            if (sliderItem == null)
            {
                throw new Exception("bu id'e uygun sliderItem tapilamdi.");
            }
            if (sliderItem.IsDeleted)
            {
                throw new Exception("bu id'e uygun sliderItem tapilamdi.");
            }
            sliderItem.IsDeleted = true;
            sliderItem.LastModifiedDate= DateTime.Now;   
            sliderItem.DeletedDate= DateTime.Now;   
            await _context.SaveChangesAsync();
        }
        public async Task HardDeleteSliderItemAsync(int id)
        {
            SliderItem sliderItem = await _context.SliderItem.SingleOrDefaultAsync(x => x.Id == id);
            if (sliderItem == null)
            {
                throw new Exception("bu id'e uygun sliderItem tapilamdi.");
            }
            if (!sliderItem.IsDeleted)
            {
                throw new Exception("bu id'e uygun sliderItem softDelete olunmayib.");
            }
            _context.SliderItem.Remove(sliderItem);

            await _context.SaveChangesAsync();
        }
        public async Task CreateSliderItemAsync(SliderItem sliderItem)
        {
            await _context.SliderItem.AddAsync(sliderItem);
            int row = await _context.SaveChangesAsync();
            if (row != 1) 
            {
                throw new Exception("nese sehvdir");
            }
               
        }      
       public async Task UpdateSliderItemAsync(int id, SliderItem sliderItem)
        {
            if (id != sliderItem.Id) 
            {
                throw new Exception("bu id'e uygun sliderItem tapilamdi");
            }
            SliderItem? baseSliderItem = await _context.SliderItem.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            if (baseSliderItem == null)
            {
                throw new Exception("bu id'e uygun sliderItem tapilamdi.");
            }
            baseSliderItem.Title = sliderItem.Title;
            baseSliderItem.ShortDescription = sliderItem.ShortDescription;
            baseSliderItem.Offer = sliderItem.Offer;
            baseSliderItem.LastModifiedDate= sliderItem.LastModifiedDate;

            _context.SliderItem.Update(sliderItem);
            await _context.SaveChangesAsync();
        }
    }
}