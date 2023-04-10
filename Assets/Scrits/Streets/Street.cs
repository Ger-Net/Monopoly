using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Street : MonoBehaviour
{
    [SerializeField] protected int _cost;

    protected IBought _bought;
    protected IActing _acting;
    protected abstract void InitBehaviours();
    private void Awake()
    {
        InitBehaviours();
    }
    public bool Buy(Player player)
    {
        return _bought.TryBuy(player,_cost);
    }

    
}
