using UnityEngine;

public class BonusStreet : Street
{
   
    private void Start()
    {
        PlayerMover playerMover = FindObjectOfType<PlayerMover>();
        playerMover.BonusStreetStand += GetBonus;
    }

    public void GetBonus(Player player)
    {
        int randomValue = Random.Range(0, 2);
        switch (randomValue)
        {
            case 0:
                GiveMoney(player);
                break;
            case 1:
                TakeMoney(player);
                break;
        }
    } 
    private void GiveMoney(Player player)
    {
        player.Money += 150;
        Debug.Log("Money");
    }
    private void TakeMoney(Player player)
    {
        player.Money -= 100;
        Debug.Log("Tax");
    }

}
