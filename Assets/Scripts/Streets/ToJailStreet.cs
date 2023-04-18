using Assets.Scrits.Behaviours;
using Assets.Scrits.Behaviours.Act;
using Assets.Scrits.Behaviours.Pass;
using UnityEngine;

public class ToJailStreet : Street
{
    [SerializeField] private Jail _jail;
    protected override void InitBehaviours()
    {
        _passing = new EmptyPassBehaviour(); 
        _bought = new DontBoughtBehaviour();
        _acting = new ToJailActBehaviour(_jail);
    }
}
