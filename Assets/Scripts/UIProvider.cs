using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProvider : MonoBehaviour
{
    public static UIProvider instance;

    [SerializeField] private TextMeshProUGUI currentPlayer;
    [SerializeField] private TextMeshProUGUI currentPlayerMoney;
    [SerializeField] private Button endTurnButton;
    [SerializeField] private Button diceButton;
    [SerializeField] private Button rentButton;
    [SerializeField] private Button buyButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerMover playerMover = FindObjectOfType<PlayerMover>();
        playerMover.StandOnOtherPlayerStreet += RentWaiting;
        buyButton.onClick.AddListener(PlayerTextChange);
        rentButton.onClick.AddListener(PlayerTextChange);

        PlayerTextChange();
    }
    public void StartMove()
    {
        diceButton.gameObject.SetActive(true);
        PlayerTextChange();
    }

    private void PlayerTextChange()
    {
        currentPlayerMoney.text = $"Money {GameLogic.instance.GetCurrentPlayer().Money}";
        currentPlayer.text = $"Now {GameLogic.instance.GetCurrentPlayer().name} move's";
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
