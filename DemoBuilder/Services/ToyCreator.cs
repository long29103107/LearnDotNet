using DemoBuilder.Models;

namespace DemoBuilder.Services
{
    public class ToyCreator
    {
        private IToyBuilder _toyBuilder;
        public ToyCreator(IToyBuilder toyBuilder)
        {
            _toyBuilder = toyBuilder;
        }
        public void CreateToy()
        {
            _toyBuilder.SetModel();
            _toyBuilder.SetHead();
            _toyBuilder.SetLimbs();
            _toyBuilder.SetBody();
            _toyBuilder.SetLegs();
        }
        public Toy GetToy()
        {
            return _toyBuilder.GetToy();
        }
    }
}
