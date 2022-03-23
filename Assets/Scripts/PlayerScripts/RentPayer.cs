using UnityEngine;

public class RentPayer : MonoBehaviour
{
    public void PayRent()
    {
        Player currentPlayer = GameLogic.singleTon.GetCurrentPlayer();
        Player owner = GameLogic.singleTon.GetStreet(currentPlayer.CurrentPosition).Owner;

        if (owner == null || currentPlayer == owner) 
        {
            Debug.Log("Street has not owner or owner is current player");
            return;
        }

        Debug.Log(currentPlayer.name + " is pay rent to " + owner.name);
        owner.Money += GameLogic.singleTon.GetStreet(currentPlayer.CurrentPosition).Rent;
        currentPlayer.Money -= GameLogic.singleTon.GetStreet(currentPlayer.CurrentPosition).Rent;
    }
}
