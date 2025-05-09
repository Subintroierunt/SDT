using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private List<Rigidbody> ragdolls = new List<Rigidbody>();

        private void Start()
        {
            ragdolls.ForEach(r => r.isKinematic = true);
        }

        public void SetAnimation(CharacterStates state)
        {
            animator.ResetTrigger(state.ToString());
            animator.SetTrigger(state.ToString());
        }

        public void SetRagdoll(bool mode)
        {
            animator.enabled = !mode;
            ragdolls.ForEach(r => r.isKinematic = !mode);
        }
    }
}
