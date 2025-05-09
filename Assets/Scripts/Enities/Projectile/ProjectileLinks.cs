using UnityEngine;

namespace Entities
{
    public class ProjectileLinks : MonoBehaviour
    {
        [SerializeField] private ProjectileMove projectileMove;
        [SerializeField] private ProjectileHit projectileHit;

        public ProjectileMove Move => projectileMove;
        public ProjectileHit Hit => projectileHit;
    }
}
