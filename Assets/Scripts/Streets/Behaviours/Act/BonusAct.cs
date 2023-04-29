using System;

namespace Assets.Scrits.Behaviours
{
    public class BonusActBehaviour : IActing
    {
        public void Act(Player player)
        {
            AddRandomBonus(player);
        }
        private void AddRandomBonus(Player player)
        {
            int r = new Random().Next(0,3);
            switch (r) 
            {
                case 0:
                    player.AddMoney(500);
                    break;
                case 1:
                    player.AddMoney(100);
                    break;
                case 2:
                    player.RemoveMoney(100);
                    break;
                default:
                    break;
            }
        }
    }
}
