using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProvider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentPlayer;
    [SerializeField] private TextMeshProUGUI currentPlayerMoney;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button diceButton;
    [SerializeField] private Button rentButton;

    private void Awake()
    {
        PlayerMover playerMover = FindObjectOfType<PlayerMover>();

        playerMover.StandOnOtherPlayerStreet += RentWaiting;

        GameLogic.singleTon.SecondTurn += SecondMove;

        currentPlayerMoney.text = $"Money {GameLogic.singleTon.GetCurrentPlayer().Money}";
        currentPlayer.text = $"Now {GameLogic.singleTon.GetCurrentPlayer().name} move's";
    }

    public void StartMove()
    {
        diceButton.gameObject.SetActive(true);
        currentPlayerMoney.text = $"Money {GameLogic.singleTon.GetCurrentPlayer().Money}";
        currentPlayer.text = $"Now {GameLogic.singleTon.GetCurrentPlayer().name} move's";
    }

    public void EndMove()
    {
        diceButton.gameObject.SetActive(false);
    }
    public void SecondMove()
    {
        diceButton.gameObject.SetActive(true);
    }
    private void RentWaiting()
    {
        endTurnButton.gameObject.SetActive(false);
        rentButton.gameObject.SetActive(true);
    }
}
