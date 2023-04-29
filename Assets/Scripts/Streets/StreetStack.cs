using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrits.Streets
{
    [Serializable]
    public class StreetStack
    {
        public event Action<StreetStack> StackCompleted;

        public uint multiply;
        public int count;
        public StreetColor color;

        private List<SimpleStreet> _streets;
        private bool _checked = false;
        
        public void Init()
        {
            _streets = new();
            _checked = false;
        }
        public void AddStreet(SimpleStreet street)
        {
            _streets.Add(street);
            Debug.Log($"Adding street...\nCurrent streets: {_streets.Count}");
            Subscribe(street);
            Check();
        }
        public void RemoveStreet(SimpleStreet street)
        {
            _streets.Remove(street);
            Unsubscribe(street);
        }
        public void Check()
        {
            if (_streets.Count != count || _checked != false)
            {
                Debug.LogAssertion($"Dont Check {_streets.Count != count} {_checked != false}");
                return;
            }
            Player baseOwner = _streets[0].Owner;
            foreach (var street in _streets)
            {
                if (street.Owner != baseOwner)
                {
                    Debug.LogAssertion("Dont Check Owner");
                    return;
                }

            }

            Debug.Log("Invoke");

            StackCompleted?.Invoke(this);
            foreach (var street in _streets)
            {
                Unsubscribe(street);
            }
            _checked = true;
        }
        private void Subscribe(SimpleStreet street)
        {
            StackCompleted += street.OnFullStackCompleted;
        }
        private void Unsubscribe(SimpleStreet street)
        {
            StackCompleted -= street.OnFullStackCompleted;
        }
    }
    public enum StreetColor
    {
        Red, Blue, Violet, Salad, Orange, Yellow, Green, Pink
    }
}