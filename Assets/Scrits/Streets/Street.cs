using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Street : MonoBehaviour
{
    [SerializeField] protected int _cost = 50;
    [SerializeField] private int _index;

    protected IBought _bought;
    protected IActing _acting;
    protected IPass _passing;
    protected abstract void InitBehaviours();

    public int Cost => _cost;
    private void Awake()
    {
        InitBehaviours();
    }
    public bool Buy(Player player)
    {
        return _bought.TryBuy(player);
    }
    public void Act(Player player)
    {
        _acting.Act(player);
    }
    public void Pass(Player player)
    {
        _passing.Pass(player);
    }
    
}
