using System;
using UnityEngine;

namespace Entities
{
    public class ProjectileHit : MonoBehaviour
    {
        public event Action<ProjectileHit> Hitted;

        private int damage;
        private CharacterHealth target;

        public void SetDamage(int damage) =>
            this.damage = damage;

        public void SetTarget(CharacterHealth target) => 
            this.target = target;

        public void LifeTimeEnd() =>
            Hitted?.Invoke(this);

        private void OnTriggerEnter(Collider other)
        {
            Hitted?.Invoke(this);
            target.TakeDamage(damage);
        }
    }
}
