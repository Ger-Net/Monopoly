using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetByer : MonoBehaviour
{
    private Player player;
    private Street street;

    public void BuyStreet()
    {
        player = GameLogic.singleTon.GetCurrentPlayer();
        street = GameLogic.singleTon.GetStreet(player.CurrentPosition);
        if (!street.IsBought() && !(street is INotBuyStreet))
        {
            player.streets.Add(street);
            player.Money -= street.Cost;
            street.SetBoughtTrue();
            GameLogic.singleTon.GetStreet(player.CurrentPosition).Owner = player;
            Debug.Log("Player " + player.name + " is owner of " + street.name + " street");
        }
        else
        {
            Debug.Log("Can't buy street");
        }
    }
}
