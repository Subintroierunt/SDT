using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities
{
    public class CharacterShoot : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float bulletSpeed = 5;

        [SerializeField] private ProjectilePool pool;
        [SerializeField] private InputAction tap;
        [SerializeField] private InputAction pos;

        [SerializeField] private Transform gunPoint;

        private void Start()
        {
            tap.Enable();
            pos.Enable();
            tap.performed += _ => TryCreateBullet();
        }

        private void TryCreateBullet()
        {
            Ray ray = Camera.main.ScreenPointToRay(pos.ReadValue<Vector2>());
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            CharacterHealth enemy;

            if (enemy = hit.collider?.GetComponent<CharacterHealth>())
            {
                ProjectileLinks projectile = pool.Instantiate(gunPoint.transform.position);
                projectile.Move.Launch((hit.point - gunPoint.position), bulletSpeed);
                projectile.Hit.SetDamage(damage);
            }
            else
            {
                Debug.Log(hit.collider?.name + " Miss");
            }
        }
    }
}
