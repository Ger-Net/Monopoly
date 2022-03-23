using UnityEngine;

public class TaxStreet : Street, INotBuyStreet
{
    private void Start()
    {
        PlayerMover playerMover = FindObjectOfType<PlayerMover>();
        playerMover.TaxStreetStand += PayTax;
    }
    public void PayTax(Player player)
    {
        if (player.streets == null) return;

        player.Money -= 100 * player.streets.Count;

        Debug.Log("TAXTAX");
    }
}
