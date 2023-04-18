using Assets.Scripts.Singleton;

namespace Assets.Scrits.Behaviours.Act
{
    public class ToJailActBehaviour : IActing
    {
        private Jail _jail;
        public ToJailActBehaviour(Jail jail)
        {
            _jail = jail;
        }
        public void Act(Player player)
        {
            Singleton<PlayerMovement>.Instance.Move(new() { _jail }, player);
            player.Block();
        }
    }
}
