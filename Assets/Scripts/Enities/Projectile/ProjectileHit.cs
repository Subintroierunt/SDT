using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileHit : MonoBehaviour
    {
        public event Action<ProjectileHit> Hitted;

        private int damage;

        public void SetDamage(int damage) =>
            this.damage = damage;

        public void LifeTimeEnd() =>
            Hitted?.Invoke(this);

        private void OnTriggerEnter(Collider other)
        {
            Hitted?.Invoke(this);
            CharacterHealth enemy;
            if (enemy = other.transform.root.GetComponent<CharacterHealth>())
            {
                enemy.TakeDamage(damage);
            }

            Debug.Log("Hit " + other.transform.root.name);

        }
    }
}
