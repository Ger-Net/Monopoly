using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private Dice[] _dices;
    private int _firstDice;
    private int _secondDice;
    public int Roll()
    {
        _firstDice = _dices[0].Roll();
        _secondDice = _dices[1].Roll();

        return _firstDice + _secondDice;
    }

    public bool HasDouble()
    {
        return _firstDice == _secondDice;
    }
}
