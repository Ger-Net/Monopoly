using Assets.Scripts.Singleton;
using Assets.Scripts.UI.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private int _debugStreetIndex; 

    [SerializeField] private int _playerCount = 4;
    [SerializeField] private Player[] _players;
    [SerializeField] private Street[] _streets;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private DiceController _diceController;
    //debug
    [SerializeField]
    private Player _currentPlayer;
    private int _currentPlayerIndex = -1;
    private int _currentPlayerMoveIndex;
    private bool _canMove = true;
    private bool _isMoving = false;
    private void Awake()
    {
        //_playerMovement.OnMoveEnded += EndMove;
        NextPlayer();
        Singleton<EndTurnController>.Instance.OnClick += EndMove; 
    }
    public void StartTurn()
    {
        if (_isMoving && !_canMove || _currentPlayer.Blocked)
        {
            Debug.LogAssertion("Can't move");
            return;
        }

        _isMoving = true;

        int diceNumber = _diceController.Roll();
        _canMove = _diceController.HasDouble();

        _currentPlayerMoveIndex++;

        int nextStreetIndex = (_currentPlayer.CurrentStreetIndex + diceNumber) % _streets.Length;

        List<Street> streetsToMove = GetStreetsToMove(nextStreetIndex);

        _playerMovement.Move(streetsToMove, _currentPlayer);
    }

    #region Debug
    public void StartTurnDebug()
    {
        if (_isMoving)
            return;
        _isMoving = true;

        _playerMovement.DebugMove(_streets[_debugStreetIndex], _currentPlayer);
    }
    #endregion

    public void EndMove()
    {
        
        if (_canMove && _currentPlayer.Blocked == false)
        {
            Debug.LogAssertion("Move once more time");
            return;
        }
        if (_currentPlayer.Blocked)
        {
            _currentPlayer.Block();
        }
        NextPlayer();

        _isMoving = false;
        _canMove = true;
    }
    private void NextPlayer()
    {
        _currentPlayerMoveIndex = 0;
        _currentPlayerIndex++;
        _currentPlayer = _players[_currentPlayerIndex % _playerCount];
    }
    private List<Street> GetStreetsToMove(int nextStreetIndex)
    {
        List<Street> streetsToMove = new();
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
