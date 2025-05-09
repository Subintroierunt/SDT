using GameSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entities
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private WaypointPath path;
        [SerializeField] private CharacterAI characterAI;

        private int curWayPoint;

        private void Start()
        {
            Init(0);
        }

        public void Init(int start)
        {
            if (path != null)
            {
                curWayPoint = start;
                if (path.Waypoints.Count > 0)
                {
                    agent.transform.position = path.Waypoints[start].position;
                    agent.transform.rotation = Quaternion.identity;
                    agent.SetDestination(path.Waypoints[start].position);
                }
            }
        }

        public void NextPosition()
        {
            if (path.Waypoints.Count > 0)
            {
                curWayPoint = (curWayPoint + 1) % path.Waypoints.Count;
                agent.SetDestination(path.Waypoints[curWayPoint].position);
            }
            else
            {
                characterAI.ChangeState(CharacterStates.idle);
            }
            
        }

        private void Update()
        {
            if (characterAI.State == CharacterStates.run && Vector3.Distance(agent.destination, transform.position) < 0.01f)
            {
                characterAI.ChangeState(CharacterStates.idle);
            }
        }
    }
}
