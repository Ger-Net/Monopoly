using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetByer : MonoBehaviour
{
    [SerializeField] private GameLogic gameLogic;

    private Player player;
    private Street street;

    public void BuyStreet()
    {
        player = gameLogic.GetCurrentPlayer();
        street = gameLogic.GetStreet(player.CurrentPosition);
        if (!street.IsBought() && !(street is JailStreet) && !(street is BonusStreet) && !(street is TaxStreet))
        {
            player.streets.Add(street);
            player.Money -= street.Cost;
            street.SetBoughtTrue();
            gameLogic.GetStreet(player.CurrentPosition).Owner = player;
            Debug.Log("Player " + player.name + " is owner of " + street.name + " street");
        }
        else
        {
            Debug.Log("Can't buy street");
        }
    }
}
