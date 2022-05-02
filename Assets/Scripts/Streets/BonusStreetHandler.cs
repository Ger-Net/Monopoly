using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStreetHandler : MonoBehaviour
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
        player.Money += Random.Range(15, 30);
        Debug.Log("M");
    }
    private void TakeMoney(Player player)
    {
        player.Money -= Random.Range(10, 20);
        Debug.Log("T");
    }


}
