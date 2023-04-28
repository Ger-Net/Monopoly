using Assets.Scrits.Streets;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serializable only for debug
    [SerializeField] private List<SimpleStreet> _streets = new List<SimpleStreet>();

    //serializable only for debug
    [SerializeField] private int _currentStreetIndex;
    [SerializeField] private int _money;

    [SerializeField] private PlayerColor _color;

    private int _blockTurnCount = 0;

    public bool Blocked { get; private set; } = false;

    public PlayerColor Color => _color;
    public int Money => _money;
    public int CurrentStreetIndex
    {
        get => _currentStreetIndex;
        set => _currentStreetIndex = value;
    }

    #region Money
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
    #endregion

    #region Streets 
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

    #endregion
    
    public void Block()
    {
        _blockTurnCount++;
        Blocked = _blockTurnCount % 3 != 0;
    }
}
public enum PlayerColor
{
    None, Black, Green, Blue, Red
}
