using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class WaypointPath : MonoBehaviour
    {
        [Tooltip("If off you need manualy put waypoints into list")]
        [SerializeField] private bool useAutoDetect = true;
        [SerializeField] private List<Transform> waypoints = new List<Transform>();

        public List<Transform> Waypoints =>
            waypoints;

        private void Start()
        {
            if (useAutoDetect)
            {
                waypoints.Clear();
                for (int i = 0; i < transform.childCount; i++)
                {
                    waypoints.Add(transform.GetChild(i));
                }
            }
        }
    }
}
