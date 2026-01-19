using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Views
{
    public class PlayerInfoView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void UpdateText(int money)
        {
            _moneyText.text = $"Money: {money}";
        }
    }
}
