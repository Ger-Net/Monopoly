using Assets.Scrits.Behaviours;
using Assets.Scrits.Behaviours.Pass;

public class BonusStreet : Street
{
    protected override void InitBehaviours()
    {
        _passing = new EmptyPassBehaviour();
        _bought = new DontBoughtBehaviour();
        _acting = new BonusActBehaviour();
    }
}
