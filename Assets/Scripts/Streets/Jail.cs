using Assets.Scrits.Behaviours;
using Assets.Scrits.Behaviours.Pass;

public class Jail : Street
{
    protected override void InitBehaviours()
    {
        _acting = new DontActBehaviour();
        _bought = new DontBoughtBehaviour();
        _passing = new EmptyPassBehaviour();
    }
}
