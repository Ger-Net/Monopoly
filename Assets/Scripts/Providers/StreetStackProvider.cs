using Assets.Configs;
using Assets.Scrits.Streets;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class StreetStackProvider : MonoBehaviour
    {
        [SerializeField] private StreetsStackConfig _config;

        private void Awake()
        {
            foreach (var streetStack in _config.streetStacks)
            {
                streetStack.Init();
                Debug.Log($"Current streetStack {streetStack.color}");
                Debug.Log($"Current streets: {streetStack._streets.Count}");
            }
        }

        public void AddStreet(SimpleStreet simpleStreet)
        {
            _config.streetStacks.Where(t=> t.color == simpleStreet.Color).First().AddStreet(simpleStreet);
        }
        public void RemoveStreet(SimpleStreet simpleStreet)
        {
            _config.streetStacks.Where(t => t.color == simpleStreet.Color).First().RemoveStreet(simpleStreet);
        }
    }
}
