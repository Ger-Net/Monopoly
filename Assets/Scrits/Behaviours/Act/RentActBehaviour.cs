using Assets.Scrits.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrits.Behaviours.Act
{
    public class RentActBehaviour : IActing
    {
        private SimpleStreet _street;
        public RentActBehaviour(SimpleStreet street)
        {
            _street = street;   
        }
        public void Act(Player player)
        {
            if (_street.Owner == null || _street.Owner == player)
                return;
            _street.Owner.AddMoney(_street.Rent);
            player.RemoveMoney((int)_street.Rent);
        }
    }
}
