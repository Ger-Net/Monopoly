using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetByer : MonoBehaviour
{
    private Player player;
    private Street street;

    [SerializeField] private StreetComplectProvider streetComplect;
    public void BuyStreet()
    {
        player = GameLogic.instance.GetCurrentPlayer();
        street = GameLogic.instance.GetStreet(player.CurrentPosition);
        if (!street.IsBought() && !(street is INotBuyStreet))
        {
            player.streets.Add(street);
            player.Money -= street.Cost;
            streetComplect.CheckComplectDoned(player.streets,street.Type);
            street.SetBoughtTrue();
            street.Owner = player;
            Debug.Log("Player " + player.name + " is owner of " + street.name + " street");
        }
        else
        {
            Debug.Log("Can't buy street");
        }
    }
}
