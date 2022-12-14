using RoboTech.Models;

namespace RoboTech.ViewModels
{
    public class HomeVM
    {
        public TbSlide? Slide { get; set; }
        public List<TbSlide>? Slides { get; set; }
        public TbSlide? Banner_Left { get; set; }

        public TbSlide? Banner_right { get; set; }
        public IEnumerable<TbProduct>? Product { get; set; }

    }
}
