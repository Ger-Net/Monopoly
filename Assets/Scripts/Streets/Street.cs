using UnityEngine;

public class Street : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int streetNumber;

    private bool bought = false;

    public int NumberOfStreet => streetNumber;
    public int Rent => cost * 2; 
    public int Cost => cost;
    public Player Owner { get; set; }

    public bool IsBought() => bought;

    public void SetBoughtTrue() => bought = true;

}
