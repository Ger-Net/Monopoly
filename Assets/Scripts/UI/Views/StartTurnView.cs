using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Views
{
    public class StartTurnView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button Button => _button;
    }
}
