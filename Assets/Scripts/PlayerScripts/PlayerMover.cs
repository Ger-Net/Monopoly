using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class PlayerMover : MonoBehaviour
{
    public event Action Moved;
    public event Action StandOnOtherPlayerStreet;
    public event Action LapEnd;

    public event Action<Player> BonusStreetStand;
    public event Action<Player> TaxStreetStand;
    public event Action<Player> JailStreetStand;

    [SerializeField] private GameLogic game;

    private JailStreet jail;

    public void Start()
    {
        jail = FindObjectOfType<JailStreet>();
    }

    public void PlayerMove()
    {
        if (!game.IsTurnOver())
            return;
        Player player = game.GetCurrentPlayer();
        if (player.IsInJail) 
        {
            jail.Pass();
            Debug.Log($"Player {player.name} is in jail");
            return;
        }
        int streetnumber = player.CurrentPosition;
        int dicesValue = game.SetSteps();
        int newStreetNumber = streetnumber + dicesValue;

        if (newStreetNumber > 33) 
        {
            newStreetNumber -= 34;
            LapEnd?.Invoke();
        }

        Transform streetTransform = game.GetStreet(newStreetNumber).transform;
        MoveToPosition(player, streetTransform.position.x, streetTransform.position.y);
        Debug.Log($"Player {player.name} - Now Position is: {newStreetNumber}");
        
        player.CurrentPosition = newStreetNumber;

        Player owner = game.GetStreet(player.CurrentPosition).Owner;

        // Активация событий
        Moved?.Invoke();
        game.SecondTurn?.Invoke();
        if (owner != null && player != owner) StandOnOtherPlayerStreet?.Invoke();
        if (game.GetStreet(newStreetNumber) is TaxStreet) TaxStreetStand?.Invoke(player);
        if (game.GetStreet(newStreetNumber) is BonusStreet) BonusStreetStand?.Invoke(player);
        if (game.GetStreet(newStreetNumber) is ToJailStreet) JailStreetStand?.Invoke(player);
    }

    private void MoveToPosition(Player player,float x, float y)
    {
        float randomValueX = Random.Range(0.1f, 0.5f);
        float randomValueY = Random.Range(0.1f, 0.5f);
        player.transform.position = new Vector2(x + randomValueX, y + randomValueY);
    }
}
