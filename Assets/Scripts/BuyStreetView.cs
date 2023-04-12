using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BuyStreetView : MonoBehaviour
    {
        [SerializeField] private GameObject _buyPanel;
        [SerializeField] private Button _buyButton;
        public void OpenPanel()
        {
            _buyPanel.SetActive(true);
        }
        public void Buy()
        {

        }
    }
}
