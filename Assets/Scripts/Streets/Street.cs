using UnityEngine;

public class Street : MonoBehaviour
{

    [SerializeField] private int rent;
    [SerializeField] private int cost;
    [SerializeField] private int streetNumber;

    private Player owner;
    private bool bought = false;

    public int Rent => rent; 
    public int Cost => cost;
    public Player Owner { get => owner; set => owner = value; }

    public int GetNumberOfStreet()
    {
        return streetNumber;
    }

    public bool IsBought()
    {
        return bought;
    }

    public void SetBoughtTrue()
    {
        bought = true;
    }
    
}
