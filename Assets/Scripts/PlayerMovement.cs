using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action OnMoveEnded;

    [SerializeField] private float _moveDuration = 0.3f;
    private bool _isMoving;
    public void Move(List<Street> streets, Player player)
    {
        StartCoroutine(AnimateMove(streets,player));
    }
    private IEnumerator AnimateMove(List<Street> streets,Player player)
    {
        for (int i = 1; i < streets.Count; i++)
        {
            Street street = streets[i];
            street.Pass(player);
            _isMoving = true;
            player.transform.DOMove(street.transform.position, _moveDuration)
                .OnComplete(() => _isMoving = false);
            while (_isMoving)
            {
                yield return null;
            }
        }
        player.CurrentStreetIndex = streets.Last().Index;
        streets.Last().Act(player);
        streets.Last().Buy(player);
        OnMoveEnded?.Invoke();
    }
}
