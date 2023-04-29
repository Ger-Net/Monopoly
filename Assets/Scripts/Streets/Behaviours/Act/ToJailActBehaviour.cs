using Assets.Scripts.Singleton;
using UnityEngine;

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
            Debug.Log("Moving");
            Singleton<PlayerMovement>.Instance.Move(new() {null, _jail }, player);
            player.Block();
        }
    }
}
