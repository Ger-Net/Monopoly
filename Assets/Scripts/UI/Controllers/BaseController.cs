using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Controllers
{
    public abstract class BaseController : MonoBehaviour
    {
        public event Action OnClick;

        protected void Invoke()
        {
            OnClick?.Invoke();
        }

        protected void ClearEvent()
        {
            OnClick = null;
        }
        
        public void AddListener(Action action)
        {
            OnClick += action;
        }
    }
}
