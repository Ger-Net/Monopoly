using UnityEngine;

public enum StreetType : byte
{
    brown, violet, greyBlue, darkGreen, red, black, orange, pink, lightGreen, darkRed, NONE
}
public class Street : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int streetNumber;
    [SerializeField] private StreetType type;

    private bool bought = false;

    public int NumberOfStreet => streetNumber;
    public int Cost { get => cost; set => cost = value; }
    public Player Owner { get; set; }
    public StreetType Type { get => type; }

    public bool IsBought() => bought;

    public void SetBoughtTrue() => bought = true;
}
