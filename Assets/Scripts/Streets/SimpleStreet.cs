using Assets.Scrits.Behaviours.Act;
using Assets.Scrits.Behaviours.Buy;
using Assets.Scrits.Behaviours.Pass;
using UnityEngine;

namespace Assets.Scrits.Streets
{
    public class SimpleStreet : Street
    {
        [SerializeField] protected uint _cost = 50;
        [SerializeField] private uint _rent;
        //serializable only for debug
        [SerializeField] private Player _owner;
        public Player Owner => _owner;
        public uint Rent => _rent; 
        public uint Cost => _cost;
        protected override void InitBehaviours()
        {
            _bought = new SimpleBoughtBehaviour(this);
            _passing = new EmptyPassBehaviour();
            _acting = new RentActBehaviour(this);
        }
        public void AddOwner(Player player)
        {
            _owner = player;
        }
        public void RemoveOwner() 
        {
            _owner = null;
        }
    }
}
