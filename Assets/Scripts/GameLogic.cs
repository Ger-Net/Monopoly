using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    [SerializeField] private List<Player> players;
    [SerializeField] private Street[] streets;
    [SerializeField] private DiceRoll[] dices;

    private PlayerMover playerMover;
    private Player currentPlayer;

    private bool turn = true;
    private void Awake()
    {
        instance = this;
        players = FindObjectsOfType<Player>().ToList();
    }

    private void Start()
    {
        ToJailStreet toJailStreet = FindObjectOfType<ToJailStreet>();
        toJailStreet.InJail += ConvertJailFlag;

        JailStreet jail = FindObjectOfType<JailStreet>();
        jail.JailEnd += ConvertJailFlag;

        playerMover = FindObjectOfType<PlayerMover>();
        playerMover.Moved += OnMoved;
        playerMover.LapEnd += OnLapEndReward;

        currentPlayer = players[0];
    }

    #region Private methods
    private void ConvertJailFlag()
    {
        currentPlayer.IsInJail = currentPlayer.IsInJail == false;
    }
    private void OnLapEndReward() => currentPlayer.Money += 300;
    
    private void OnMoved() 
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

    #region Public methods
    public void StartMove()
    {
        ChangeCurrentPlayer();
        turn = true;
    }
    public void SecondMove()
    {
        turn = true;
        UIProvider.instance.SecondMove(); //TO FIX
        playerMover.SecondTurn -= SecondMove;
    }
    public bool IsTurnOver()
    {
        return turn;
    }
    public int SetSteps()
    {
        int step1 = dices[0].GetNumberOfSteps();
        int step2 = dices[1].GetNumberOfSteps();
        if(step1 == step2) playerMover.SecondTurn += SecondMove;

        return step1 + step2;
    }
    public Player GetCurrentPlayer() => currentPlayer;
    public Street GetStreet(int streetnumber) => streets[streetnumber];
    #endregion
}
