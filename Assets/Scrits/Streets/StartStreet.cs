using Assets.Scrits.Behaviours;
using System;
using UnityEngine;

namespace Assets.Scrits.Streets
{
    public class StartStreet : Street
    {
        [SerializeField] private uint _moneyGive = 500;
        protected override void InitBehaviours()
        {
            _bought = new DontBoughtBehaviour();
            _acting = new DontActBehaviour();
            _passing = new StartPassBehaviour(_moneyGive);
        }
    }
}
