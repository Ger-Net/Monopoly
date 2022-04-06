using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetByer : MonoBehaviour
{
    private Player player;
    private Street street;

    public void BuyStreet()
    {
        player = GameLogic.instance.GetCurrentPlayer();
        street = GameLogic.instance.GetStreet(player.CurrentPosition);
        if (!street.IsBought() && !(street is INotBuyStreet))
        {
            player.AddStreet(street);
            player.Money -= street.Cost;
            street.SetBoughtTrue();
            GameLogic.instance.GetStreet(player.CurrentPosition).Owner = player;
            Debug.Log("Player " + player.name + " is owner of " + street.name + " street");
        }
        else
        {
            Debug.Log("Can't buy street");
        }
    }
}
