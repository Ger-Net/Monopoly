using Assets.Scripts.UI.Views;
using Assets.Scrits.Behaviours.Buy;
using Assets.Scrits.Streets;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Controllers
{
    public class BuyStreetController : MonoBehaviour
    {
        public event Action OnClick;
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
            OnClick?.Invoke();
            _view.BuyButton.onClick.RemoveAllListeners();
            OnClick = null;
        }
        public void Cancel()
        {
            _view.BuyButton.onClick.RemoveAllListeners();
            OnClick = null;
            _view.Close();
        }
        public void AddListener(Action action)
        {
            OnClick += action;
        }
    }
}
