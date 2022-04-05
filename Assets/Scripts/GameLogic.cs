using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic singleTon;

    public Action SecondTurn;

    [SerializeField] private Player[] players;
    [SerializeField] private Street[] streets;
    [SerializeField] private DiceRoll[] dices;

    private PlayerMover playerMover;
    private Player currentPlayer;

    private bool turn = true;

    private void Awake()
    {
        singleTon = this;
    }

    private void Start()
    {
        ToJailStreet toJailStreet = FindObjectOfType<ToJailStreet>();
        toJailStreet.OnInJail += PassMove;

        JailStreet jail = FindObjectOfType<JailStreet>();
        jail.OnJailEnd += StartFromJail;

        playerMover = FindObjectOfType<PlayerMover>();
        playerMover.Moved += EndMove;
        playerMover.LapEnd += GiveLapReward;

        currentPlayer = players[0];
    }

    #region Приватные методы
    private void StartFromJail()
    {
        currentPlayer.IsInJail = false;
    }
    private void PassMove()
    {
        currentPlayer.IsInJail = true;
    }
    private void GiveLapReward() => currentPlayer.Money += 300;
    
    private void EndMove() 
    {
        turn = false;
    }
    
    private void ChangeCurrentPlayer()
    {
        currentPlayer = currentPlayer == players[0] ? players[1] :
            currentPlayer == players[1] ? players[2] :
            currentPlayer == players[2] ? players[0] : currentPlayer;
    }
    #endregion

    #region Публичные методы
    public void StartMove()
    {
        ChangeCurrentPlayer();
        turn = true;
    }
    public void SecondMove()
    {
        turn = true;
        SecondTurn -= SecondMove;
    }
    public bool IsTurnOver()
    {
        return turn;
    }
    public int SetSteps()
    {
        int step = dices[0].GetNumberOfSteps();
        int step2 = dices[1].GetNumberOfSteps();
        if(step == step2) SecondTurn += SecondMove;

        return step + step2;
    }
    public Player GetCurrentPlayer() => currentPlayer;
    public Street GetStreet(int streetnumber) => streets[streetnumber];
    #endregion
}
