using UnityEngine;

public abstract class Street : MonoBehaviour
{
    [SerializeField] private int _index;

    protected IBought _bought;
    protected IActing _acting;
    protected IPass _passing;

    public int Index => _index; 

    protected abstract void InitBehaviours();

    
    private void Awake()
    {
        InitBehaviours();
    }
    public void Buy(Player player)
    {
        _bought.Buy(player);
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
