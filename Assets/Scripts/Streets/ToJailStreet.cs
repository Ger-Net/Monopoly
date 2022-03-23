using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class ToJailStreet : Street, INotBuyStreet
{
    private JailStreet jail;
    public event Action OnInJail;

    private void Start()
    {
        PlayerMover playerMover = FindObjectOfType<PlayerMover>();
        playerMover.JailStreetStand += ToJail;
        jail = FindObjectOfType<JailStreet>();
    }

    private void ToJail(Player player)
    {
        player.CurrentPosition = jail.GetNumberOfStreet();
        player.transform.position = new Vector2(jail.transform.position.x + Random.Range(0.1f, 0.5f),
                                                    jail.transform.position.y + Random.Range(0.1f, 0.5f));
        Debug.Log($"{player.name} now in Jail");
        OnInJail?.Invoke();
    }
}
