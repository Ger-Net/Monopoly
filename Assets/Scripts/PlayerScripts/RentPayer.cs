using System.Collections.Generic;
using UnityEngine;

public class RentPayer : MonoBehaviour
{
    private void Start()
    {
        StreetComplectProvider complectProvider = FindObjectOfType<StreetComplectProvider>();
        complectProvider.ComplectDoned += ComplectBonusRent;
    }
    public void PayRent()
    {   
        Player currentPlayer = GameLogic.instance.GetCurrentPlayer();
        Street street = GameLogic.instance.GetStreet(currentPlayer.CurrentPosition);
        Player owner = street.Owner;

        if (owner == null || currentPlayer == owner) 
        {
            Debug.Log("Street has not owner or owner is current player");
            return;
        }

        Debug.Log(currentPlayer.name + " is pay rent to " + owner.name);
        owner.Money += street.Cost/2;
        currentPlayer.Money -= street.Cost/2;
    }

    private void ComplectBonusRent(IEnumerable<Street> streets)
    {
        foreach (var street in streets)
        {
            street.Cost *= 2;
        }
    }
}
