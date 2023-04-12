using Assets.Scripts;
using Assets.Scripts.Singleton;
using Assets.Scrits.Streets;

namespace Assets.Scrits.Behaviours.Buy
{
    public class SimpleBoughtBehaviour : IBought
    {
        private SimpleStreet _street;
        public SimpleBoughtBehaviour(SimpleStreet street)
        {
            _street = street;
        }
        public void Buy(Player player)
        {
            if (_street.Owner != null || player.Money < _street.Cost)
                return;
            Singleton<BuyStreetView>.Instance.OpenPanel();
            //player.AddStreet(_street);
            //_street.AddOwner(player);
            
                
        }
    }
}
