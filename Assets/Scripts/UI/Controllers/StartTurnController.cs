using Assets.Scripts.UI.Controllers;
using Assets.Scripts.UI.Views;
using UnityEngine;

public class StartTurnController : BaseController
{
    [SerializeField] private PlayerInfoView _infoView;

    private void Awake()
    {
        
    }
    private void StartTurn()
    {
        Invoke();
    }
}
