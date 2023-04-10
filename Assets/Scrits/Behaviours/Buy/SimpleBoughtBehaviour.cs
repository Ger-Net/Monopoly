using Assets.Scrits.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrits.Behaviours.Buy
{
    public class SimpleBoughtBehaviour : IBought
    {
        private SimpleStreet _street;
        public SimpleBoughtBehaviour(SimpleStreet street)
        {
            _street = street;
        }
        public bool TryBuy(Player player)
        {
            if (_street.Owner != null || player.Money < _street.Cost)
                return false;
            player.AddStreet(_street);
            _street.AddOwner(player);
            return true;
                
        }
    }
}
