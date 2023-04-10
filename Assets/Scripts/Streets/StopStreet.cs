using Assets.Scrits.Behaviours;
using Assets.Scrits.Behaviours.Act;
using Assets.Scrits.Behaviours.Pass;

public class StopStreet : Street
{
    protected override void InitBehaviours()
    {
        _passing = new EmptyPassBehaviour();
        _bought = new DontBoughtBehaviour();
        _acting = new StopActBehaviour();
    }
}
