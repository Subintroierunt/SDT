using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Entities
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetAnimation(CharacterStates state)
        {
            animator.ResetTrigger(state.ToString());
            animator.SetTrigger(state.ToString());
        }
    }
}
