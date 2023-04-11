using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    [SerializeField] private Dice[] _dices;

    public int Roll()
    {
        int number = 0;
        foreach (var dice in _dices)
        {
            number += dice.Roll();
        }
        return number;
    }
}
