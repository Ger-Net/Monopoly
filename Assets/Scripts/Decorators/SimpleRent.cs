using Assets.Scrits.Behaviours.Act;

namespace Assets.Scripts.Decorators
{
    public class SimpleRent : RentDecorator
    {
        private readonly uint _baseRent;
        public SimpleRent(uint baseRent,IRentProvider wrappedEntity) : base(wrappedEntity)
        {
            _baseRent = baseRent;
        }

        public override uint GetRentInternal()
        {
            return _baseRent;
        }
    }
}
