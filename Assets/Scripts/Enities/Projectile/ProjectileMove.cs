using System.Collections;
using UnityEngine;

namespace Entities
{
    public class ProjectileMove : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private ProjectileHit hit;
    
        public void Launch(Vector3 direction, float speed)
        {
            StartCoroutine(Move(direction, speed));
            hit.Hitted += _ => StopAllCoroutines();
        }

        private IEnumerator Move(Vector3 direction, float speed)
        {
            for (float i = 0; i < lifeTime; i += Time.deltaTime)
            {
                yield return null;
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
            hit.LifeTimeEnd();
        }
    }
}
