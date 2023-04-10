
namespace Assets.Scrits.Behaviours
{
    public class DontBoughtBehaviour : IBought
    {
        public bool TryBuy(Player player)
        {
            return false;
        }
    }
}
