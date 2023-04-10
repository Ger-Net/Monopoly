using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrits.Behaviours
{
    public class DontBoughtBehaviour : IBought
    {
        public bool TryBuy(Player player, int cost)
        {
            return false;
        }
    }
}
