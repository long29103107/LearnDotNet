using DemoBuilder.Models;

namespace DemoBuilder.Services
{
    public class ToyBBuilder : IToyBuilder
    {
        Toy toy = new Toy();
        public void SetModel()
        {
            toy.Model = "TOY B";
        }
        public void SetHead()
        {
            toy.Head = "1";
        }
        public void SetLimbs()
        {
            toy.Limbs = "4";
        }
        public void SetBody()
        {
            toy.Body = "Steel";
        }
        public void SetLegs()
        {
            toy.Legs = "4";
        }
        public Toy GetToy()
        {
            return toy;
        }
    }
}
