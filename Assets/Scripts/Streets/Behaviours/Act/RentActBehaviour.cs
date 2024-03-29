﻿using Assets.Scrits.Streets;
using UnityEngine;

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
            Debug.Log($"{player.name} is pay rent {_street.GetRent()} to {_street.Owner.name}");

            _street.Owner.AddMoney(_street.GetRent());
            player.RemoveMoney((int)_street.GetRent());
        }
    }
}
