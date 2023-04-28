using Assets.Scrits.Behaviours.Act;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Decorators
{
    public abstract class RentDecorator : IRentProvider
    {
        protected readonly IRentProvider _wrappedEntity;
        protected RentDecorator(IRentProvider wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }
        public uint GetRent()
        {
            return GetRentInternal();
        }
        public abstract uint GetRentInternal();
    }
}
