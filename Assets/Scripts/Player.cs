using Assets.Scrits.Streets;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serializable only for debug
    [SerializeField] private List<SimpleStreet> _streets = new List<SimpleStreet>();

    [SerializeField] private int _money;
    
    //serializable only for debug
    [SerializeField] private int _currentStreetIndex;
    
    public int Money => _money;
    public int CurrentStreetIndex
    {
        get => _currentStreetIndex;
        set => _currentStreetIndex = value;
    }

    public void AddMoney(uint money)
    {
        _money += (int)money;
    }

    public void RemoveMoney(int money) 
    {  
        if(money < 0)
        {
            money = -money;
        }
        _money -= money;
    }

    /// <summary>
    ///     When using this method don't use RemoveMoney
    /// </summary>
    /// <param name="street"></param>
    public void AddStreet(SimpleStreet street)
    {
        RemoveMoney((int)street.Cost);
        _streets.Add(street);
    }
    public void RemoveStreet(SimpleStreet street)
    {
        _streets.Remove(street);
    }
}
public enum PlayerColor
{
    Black, Green, Blue, Red
}
