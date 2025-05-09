using Entities;
using UnityEngine;

namespace GameSystems
{
    public class SetPlayerState : GameAction
    {
        [SerializeField] private CharacterAI player;
        [SerializeField] private CharacterStates state;

        public override void Invoke()
        {
            base.Invoke();
            player.ChangeState(state);
        }
    }
}
