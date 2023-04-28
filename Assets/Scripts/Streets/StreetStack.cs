using System;
using System.Collections.Generic;

namespace Assets.Scrits.Streets
{
    [Serializable]
    public class StreetStack
    {
        public event Action<StreetStack> StackCompleted;

        public uint multiply;
        public int count;
        public StreetColor color;

        private List<SimpleStreet> _streets = new();
        private bool _checked = false;
        

        public void AddStreet(SimpleStreet street)
        {
            _streets.Add(street);
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
            if (_streets.Count == count && _checked == false)
            {
                Player baseOwner = _streets[0].Owner;
                foreach (var street in _streets)
                {
                    if (street.Owner != baseOwner)
                        return;
                }
                foreach (var street in _streets)
                {
                    Unsubscribe(street);   
                }
                StackCompleted?.Invoke(this);
                _checked = true;
                
            }
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