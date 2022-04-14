using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public event Action MoneyChanged;

    [SerializeField] private int money;

    public int inJailCounter;

    public List<Street> streets;

    public int CurrentPosition { get ; set ; }
    public bool IsInJail { get; set; } = false;
    public int Money { get => money; 
        set 
        { 
            money = value;
            MoneyChanged?.Invoke();
        } 
    }

    private void OnEnable()
    {
        CurrentPosition = 0;
        Money = 200;
    }
    
    
}
