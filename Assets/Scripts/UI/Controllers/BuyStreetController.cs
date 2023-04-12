using Assets.Scripts.UI.Views;
using Assets.Scrits.Behaviours.Buy;
using Assets.Scrits.Streets;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Controllers
{
    public class BuyStreetController : BaseController
    {
        [SerializeField] private BuyStreetView _view;

        private void Awake()
        {
            _view.CancelButton.onClick.AddListener(Cancel);
        }
        public void Open(SimpleStreet street)
        {
            _view.BuyButton.onClick.AddListener(Buy);
            _view.Open();
            _view.SetText(street);
        }

        public void Buy()
        {
            Invoke();
            ClearEvent();
            _view.BuyButton.onClick.RemoveAllListeners();
            _view.Close();
        }
        public void Cancel()
        {
            _view.BuyButton.onClick.RemoveAllListeners();
            ClearEvent();
            _view.Close();
        }
        
    }
}
