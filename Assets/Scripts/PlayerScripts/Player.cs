using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int money;

    private List<Street> streets;

    public int CurrentPosition { get ; set ; }
    public bool IsInJail { get; set; } = false;
    public int Money { get => money; set => money = value; }

    public void AddStreet(Street street)
    {
        streets.Add(street);
    }
    public bool IsStreetListEmpty()
    {
        return streets == null;
    }

    public int GetStreetListCount()
    {
        return streets.Count;
    }

    private void OnEnable()
    {
        CurrentPosition = 0;
        Money = 2000;
    }
    
    
}
