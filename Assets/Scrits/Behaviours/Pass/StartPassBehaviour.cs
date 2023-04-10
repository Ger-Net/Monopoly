using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrits.Behaviours
{
    public class StartPassBehaviour : IPass
    {
        private uint _moneyGive;
        public StartPassBehaviour(uint moneyGive)
        {
            _moneyGive = moneyGive;
        }
        public void Pass(Player player)
        {
            player.AddMoney(_moneyGive);
        }
    }
}
