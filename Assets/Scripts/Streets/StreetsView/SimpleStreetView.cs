using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStreetView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerColor;

    public void SetColor(PlayerColor color)
    {
        switch (color)
        {
            case PlayerColor.Black:
                _playerColor.color = Color.black;
                break;
            case PlayerColor.Green:
                _playerColor.color = Color.green;
                break;
            case PlayerColor.Blue:
                _playerColor.color = Color.blue;
                break;
            case PlayerColor.Red:
                _playerColor.color = Color.red;
                break;
            case PlayerColor.None:
                _playerColor.color = Color.white;
                break;
        }
    }
}
