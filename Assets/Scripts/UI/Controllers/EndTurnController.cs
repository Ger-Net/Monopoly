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
        [SerializeField] private float _duration;

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
            if(Singleton.Singleton<MainGame>.Instance.CanMove && Singleton.Singleton<MainGame>.Instance.CurrentPlayer.Blocked == false)
            StartCoroutine(_view.ShowPlayer(_duration));
        }
    }
}
