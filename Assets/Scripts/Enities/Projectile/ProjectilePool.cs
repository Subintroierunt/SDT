using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectilePool<T>
    {
        private Stack<T> stack = new Stack<T>();
        private T prefab;

        public ProjectilePool(GameObject obj)
        {
            
        }
    }
}
