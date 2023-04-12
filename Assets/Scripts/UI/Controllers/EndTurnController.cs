using Assets.Scripts.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Controllers
{
    public class EndTurnController : BaseController
    {
        [SerializeField] private EndTurnView _view;

        private void Awake()
        {
            _view.Button.onClick.AddListener(EndTurn);
        }
        public void Show()
        {
            _view.ShowButton();
        }
        public void EndTurn()
        {
            Invoke();
        }
    }
}
