using System;
using UnityEngine;

namespace Entities
{
    public class CharacterHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int curHealth;

        [SerializeField] private CharacterAnimation anim;

        public event Action<CharacterHealth> Killed;
        public event Action<float> DamageTaked;

        private bool isKilled;

        public bool IsKilled =>
            isKilled;

        private void Start()
        {
            curHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (!isKilled)
            {
                if ((curHealth -= damage) <= 0)
                {
                    curHealth = 0;
                    

                    Kill();
                }
                DamageTaked?.Invoke((float)curHealth / maxHealth);
            }
        }

        public void Kill()
        {
            isKilled = true;
            anim.SetRagdoll(true);
            Killed?.Invoke(this);
        }

        public void Resurect()
        {
            isKilled = false;
            curHealth = maxHealth;
            anim.SetRagdoll(false);
        }
    }
}
