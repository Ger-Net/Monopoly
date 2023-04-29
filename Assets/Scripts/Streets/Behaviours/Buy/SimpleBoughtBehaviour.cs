using Assets.Scripts.Singleton;
using Assets.Scripts.UI.Controllers;
using Assets.Scripts.UI.Views;
using Assets.Scrits.Streets;
using System;

namespace Assets.Scrits.Behaviours.Buy
{
    public class SimpleBoughtBehaviour : IBought
    {
        private readonly SimpleStreet _street;
        private Player _player;
        public SimpleBoughtBehaviour(SimpleStreet street)
        {
            _street = street;
        }
        public void Buy(Player player)
        {
            if (_street.Owner != null || player.Money < _street.Cost)
                return;
            _player = player;
            Singleton<BuyStreetController>.Instance.Open(_street);
            Singleton<BuyStreetController>.Instance.AddListener(Action);
        }
        public void Action()
        {
            _player.AddStreet(_street);
            _street.AddOwner(_player);
        }
    }
}
