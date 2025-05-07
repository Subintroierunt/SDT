using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace GameDebug
{
    public class PointMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private InputAction click;
        [SerializeField] private InputAction mousePos;

        private void Start()
        {
            click.Enable();
            mousePos.Enable();
            click.performed += _ => SetDestination();
        }

        private void SetDestination()
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos.ReadValue<Vector2>());
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.point != null)
            {
                agent.SetDestination(hit.point);
            }
            
        }
    }
}

