using Assets.Scripts.Singleton;
using Assets.Scripts.UI.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    [SerializeField] private int _playerCount = 4;
    [SerializeField] private Player[] _players;
    [SerializeField] private Street[] _streets;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private DiceController _diceController;

    private Player _currentPlayer;
    private int _currentPlayerIndex = -1;
    private bool _isMoving = false;
    private void Awake()
    {
        //_playerMovement.OnMoveEnded += EndMove;
        Singleton<EndTurnController>.Instance.OnClick += EndMove; 
    }
    public void StartTurn()
    {
        if (_isMoving)
            return;
        _isMoving = true;
        _currentPlayerIndex++;
        _currentPlayer = _players[_currentPlayerIndex % _playerCount];
        int diceNumber = _diceController.Roll();
        int nextStreetIndex = (_currentPlayer.CurrentStreetIndex + diceNumber) % _streets.Length;

        List<Street> streetsToMove = AddStreets(nextStreetIndex);

        _playerMovement.Move(streetsToMove, _currentPlayer);
    }

    public void EndMove() => _isMoving = false;

    private List<Street> AddStreets(int nextStreetIndex)
    {
        List<Street> streetsToMove = new List<Street>();
        if(_currentPlayer.CurrentStreetIndex < nextStreetIndex)
        {
            for (int i = _currentPlayer.CurrentStreetIndex; i < nextStreetIndex + 1; i++)
            {
                streetsToMove.Add(_streets[i]);
            }
            return streetsToMove;
        }
        else
        {
            for(int i = _currentPlayer.CurrentStreetIndex; i < _streets.Length; i++)
            {
                streetsToMove.Add(_streets[i]);
            }
            for (int i = 0; i < nextStreetIndex + 1; i++)
            {
                streetsToMove.Add(_streets[i]);
            }
            return streetsToMove;
        }

        
    }
}
