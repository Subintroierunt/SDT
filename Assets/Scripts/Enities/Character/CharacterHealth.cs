using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int curHealth;

        [SerializeField] private CharacterAnimation anim;

        private void Start()
        {
            curHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if ((curHealth -= damage) <= 0)
            {
                curHealth = 0;
                Kill();
            }
            Debug.Log("Ouch " + curHealth);
        }

        public void Kill()
        {
            Debug.Log("dead");
            anim.SetRagdoll(true);
        }

        public void Resurect()
        {
            curHealth = maxHealth;
            anim.SetRagdoll(false);
        }
    }
}
