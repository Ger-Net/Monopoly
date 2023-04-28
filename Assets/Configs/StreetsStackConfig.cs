using Assets.Scrits.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Configs
{
    [CreateAssetMenu()]
    public class StreetsStackConfig : ScriptableObject
    {
        public List<StreetStack> streetStacks;
    }
}
