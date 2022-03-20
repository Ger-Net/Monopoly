using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int money;
    public List<Street> streets;

    public int CurrentPosition { get ; set ; }
    public bool IsInJail { get; set; } = false;
    public int Money { get => money; set => money = value; }

    private void OnEnable()
    {
        CurrentPosition = 0;
        Money = 2000;
    }
    
    
}
