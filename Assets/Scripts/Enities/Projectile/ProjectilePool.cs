using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private ProjectileLinks prefab;

        private Stack<ProjectileLinks> pool = new Stack<ProjectileLinks>();
        private List<ProjectileLinks> activeProjectiles = new List<ProjectileLinks>();

        public ProjectileLinks Instantiate(Vector3 pos)
        {
            ProjectileLinks projectile;
            if (pool.Count > 0)
            {
                projectile = pool.Pop();
                projectile.transform.position = pos;
                projectile.gameObject.SetActive(true);
            }
            else
            {
                projectile = Instantiate(prefab, pos, Quaternion.identity, transform);
                projectile.Hit.Hitted += ArchiveProjectile;
            }
            activeProjectiles.Add(projectile);
            return projectile;
        }

        private void ArchiveProjectile(ProjectileHit projectileHit)
        {
            ProjectileLinks projectile = null;
            activeProjectiles.ForEach(proj =>
                {
                    if (proj.Hit == projectileHit)
                    {
                        proj.gameObject.SetActive(false);
                        pool.Push(proj);
                        projectile = proj;
                    }
                }
            );
            activeProjectiles.Remove(projectile);
        }
    }
}
