using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int _baseMoney = 1500;

    private int _money;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _money = _baseMoney;
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
}