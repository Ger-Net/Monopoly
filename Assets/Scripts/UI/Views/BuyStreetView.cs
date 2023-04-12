using Assets.Scrits.Streets;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class BuyStreetView : MonoBehaviour
    {
        [SerializeField] private GameObject _buyPanel;
        [SerializeField] private TextMeshProUGUI _buyStreetName;
        [SerializeField] private TextMeshProUGUI _buyStreetCost;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _cancelButton;
        public Button BuyButton => _buyButton;
        public Button CancelButton => _cancelButton;
        public void Open()
        {
            _buyPanel.SetActive(true);
        }
        public void Close()
        {
            _buyPanel.SetActive(false);
        }
        public void SetText(SimpleStreet street)
        {
            _buyStreetCost.text = street.Cost.ToString();
            _buyStreetName.text = street.Name;
        }
    }
}
