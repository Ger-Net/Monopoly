using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StreetComplectProvider : MonoBehaviour
{
    public event Action<IEnumerable<Street>> ComplectDoned;

    public void CheckComplectDoned(List<Street> streets,StreetType type)
    {
        var CStreet = streets.Where(t => t.Type == type);
        if (CStreet.Count() == 3)
        {
            Debug.Log("Complect Done!!!!");
            ComplectDoned?.Invoke(CStreet);
        }
        else if(type == StreetType.darkRed || type == StreetType.brown || type == StreetType.pink)
        {
            if (CStreet.Count() == 2)
            {
                Debug.Log("Complect Done!!!!");
                ComplectDoned?.Invoke(CStreet);
            }
        }
    }
}
