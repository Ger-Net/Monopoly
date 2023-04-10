using Assets.Scrits.Behaviours;
using System;
using UnityEngine;

namespace Assets.Scrits.Streets
{
    public class StartStreet : Street
    {
        protected override void InitBehaviours()
        {
            _bought = new DontBoughtBehaviour();
        }
    }
}
