using Assets.Scripts.Singleton;
using Assets.Scripts.UI.Controllers;
using Assets.Scripts.UI.Views;
using UnityEngine;

public class StartTurnController : BaseController
{
    [SerializeField] private PlayerInfoView _infoView;
    [SerializeField] private StartTurnView _turnView;

    private void Awake()
    {
        _turnView.Button.onClick.AddListener(StartTurn);
    }
    private void StartTurn()
    {
        Invoke();
        Singleton<MainGame>.Instance.StartTurn();
        _infoView.UpdateText(Singleton<MainGame>.Instance.CurrentPlayer.Money);
    }
    private void OnDestroy()
    {
        _turnView.Button.onClick.RemoveAllListeners();
    }
}
