using Assets.Scrits.Behaviours.Act;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Decorators
{
    public class FullStackRent : RentDecorator
    {
        private readonly uint _multiply;
        public FullStackRent(uint multiply,IRentProvider wrappedEntity) : base(wrappedEntity)
        {
            _multiply = multiply;
        }

        public override uint GetRentInternal()
        {
            return _wrappedEntity.GetRent() * _multiply;
        }
    }
}
