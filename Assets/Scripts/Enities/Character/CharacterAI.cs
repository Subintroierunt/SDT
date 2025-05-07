using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entities
{
    public class CharacterAI : MonoBehaviour
    {
        [SerializeField] private CharacterMove move;
        [SerializeField] private CharacterAnimation anim;
        private CharacterStates state;

        public CharacterStates State => state;

        private void OnEnable()
        {
            state = CharacterStates.idle;
            Idle();
        }

        public void ChangeState(CharacterStates newState)
        {
            if (state != newState)
            {
                state = newState;
                switch (state)
                {
                    case CharacterStates.idle:
                        Idle();
                        break;
                    case CharacterStates.run:
                        Run();
                        break;
                }
            }
        }

        private void Idle()
        {
            anim.SetAnimation(CharacterStates.idle);
            StartCoroutine(DebugRun());
        }

        private void Run()
        {
            anim.SetAnimation(CharacterStates.run);
            move.NextPosition();
        }

        private IEnumerator DebugRun()
        {
            yield return new WaitForSeconds(1f);
            ChangeState(CharacterStates.run);
        }
    }
}
