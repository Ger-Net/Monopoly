using Assets.Scripts;
using Assets.Scripts.Decorators;
using Assets.Scripts.Singleton;
using Assets.Scrits.Behaviours.Act;
using Assets.Scrits.Behaviours.Buy;
using Assets.Scrits.Behaviours.Pass;
using UnityEngine;

namespace Assets.Scrits.Streets
{
    public class SimpleStreet : Street, IRentProvider
    {
        [SerializeField] private SimpleStreetView _view;

        [SerializeField] private StreetColor _color;

        [Header("Cost & rent")]
        [SerializeField] protected uint _cost = 50;
        [SerializeField] private uint _rent = 30;
        //serializable only for debug
        [SerializeField] private Player _owner;

        private IRentProvider _rentProvider;

        #region Properties
        public StreetColor Color => _color;
        public Player Owner => _owner; 
        public uint Cost => _cost;
        #endregion
        

        protected override void InitBehaviours()
        {
            _bought = new SimpleBoughtBehaviour(this);
            _passing = new EmptyPassBehaviour();
            _acting = new RentActBehaviour(this);
            _rentProvider = new SimpleRent(_rent, _rentProvider);
            
        }
        public void AddOwner(Player player)
        {
            _owner = player;
            _view.SetColor(_owner.Color);
            Singleton<StreetStackProvider>.Instance.AddStreet(this);
        }
        public void RemoveOwner() 
        {
            _owner = null;
            _view.SetColor(PlayerColor.None);
        }

        public uint GetRent()
        {
            return _rentProvider.GetRent();
        }
        public void OnFullStackCompleted(StreetStack stack)
        {
            _rentProvider = new FullStackRent(stack.multiply, _rentProvider);
        }
    }
}
