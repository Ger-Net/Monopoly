using UnityEngine;

public class RentPayer : MonoBehaviour
{

    [SerializeField] private GameLogic game;

    public void PayRent()
    {
        Player currentPlayer = game.GetCurrentPlayer();
        Player owner = game.GetStreet(currentPlayer.CurrentPosition).Owner;

        if (owner == null || currentPlayer == owner) { Debug.Log("Street has not owner or owner is current player"); return; }

        Debug.Log(currentPlayer.name + " is pay rent to " + owner.name);
        owner.Money += game.GetStreet(currentPlayer.CurrentPosition).Rent;
        currentPlayer.Money -= game.GetStreet(currentPlayer.CurrentPosition).Rent;
    }
}
