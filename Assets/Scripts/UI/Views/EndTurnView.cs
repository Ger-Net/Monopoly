using Assets.Scripts.Singleton;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class EndTurnView : MonoBehaviour
    {
        [SerializeField] private GameObject _nextPlayerPanel;
        [SerializeField] private Image _nextPlayerImage;
        [SerializeField] private TextMeshProUGUI _nextPlayerText;
        [SerializeField] private Button _button;

        public Button Button => _button;

        public void ShowButton()
        {
            _button.gameObject.SetActive(true);
        }
        public void HideButton()
        {
            _button.gameObject.SetActive(false);
        }
        public IEnumerator ShowPlayer(float duration)
        {
            Color color = Color.white;
            switch (Singleton<MainGame>.Instance.CurrentPlayer.Color)
            {
                case PlayerColor.None:
                    break;
                case PlayerColor.Black:
                    _nextPlayerText.text = "Next player — black";
                    color = Color.black;
                    break;
                case PlayerColor.Green:
                    _nextPlayerText.text = "Next player — green";
                    color = Color.green;
                    break;
                case PlayerColor.Blue:  
                    _nextPlayerText.text = "Next player — blue";
                    color = Color.blue;
                    break;
                case PlayerColor.Red:
                    _nextPlayerText.text = "Next player — red";
                    color = Color.red;
                    break;
                default:
                    break;
            }
            _nextPlayerImage.color = color;
            _nextPlayerPanel.gameObject.SetActive(true);
            yield return new WaitForSeconds(duration);
            _nextPlayerPanel.gameObject.SetActive(false);
        }
    }
}
