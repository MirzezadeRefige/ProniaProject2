using PRONIA_DAL.Models;

namespace PRONIA_BL.Services.Abstractions
{
    public interface ISliderItemService
    {
        Task<List<SliderItem>> GetAllAsync();
        Task<SliderItem> GetByIdAsync(int id);
        Task CreateSliderItemAsync(SliderItem sliderItem);
        Task UpdateSliderItemAsync(int id,SliderItem sliderItem);
        Task SoftDeleteSliderItemAsync(int id);
        Task HardDeleteSliderItemAsync(int id);
    }
}
