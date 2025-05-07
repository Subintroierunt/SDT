using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entities
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private List<Transform> wayPoints = new List<Transform>();
        [SerializeField] private CharacterAI characterAI;

        private int curWayPoint;

        private void Start()
        {
            Init(0);
        }

        private void Init(int start)
        {
            curWayPoint = start;
            agent.transform.position = wayPoints[start].position;
        }

        public void NextPosition()
        {
            curWayPoint = (curWayPoint + 1) % wayPoints.Count;
            agent.SetDestination(wayPoints[curWayPoint].position);
        }

        private void Update()
        {
            if (characterAI.State == CharacterStates.run && Vector3.Distance(agent.destination, transform.position) < 0.01f)
            {
                Debug.Log("ping");
                characterAI.ChangeState(CharacterStates.idle);
            }
        }
    }
}
