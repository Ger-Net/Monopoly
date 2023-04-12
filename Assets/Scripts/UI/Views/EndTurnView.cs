using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class EndTurnView : MonoBehaviour
    {
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
    }
}
