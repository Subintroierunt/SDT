using Entities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystems
{
    public class WaypointFightTrigger : MonoBehaviour
    {
        [Tooltip("If off you need manualy put enemies into list")]
        [SerializeField] private bool useAutoDetect = true;
        [SerializeField] private List<CharacterHealth> enemies = new List<CharacterHealth>();

        [SerializeField] private List<GameAction> actions;

        private void Start()
        {
            if (useAutoDetect)
            {
                enemies.Clear();
                for (int i = 0; i < transform.childCount; i++)
                {
                    enemies.Add(transform.GetChild(i).GetComponent<CharacterHealth>());
                }
            }

            enemies.ForEach(enemy => enemy.Killed += OnEnemyKilled);
        }

        private void OnEnemyKilled(CharacterHealth enemy)
        {
            if (enemies.Any(e => !e.IsKilled))
            {
                return;
            }
            actions.ForEach(a => a.Invoke());
        }

        private void OnDestroy()
        {
            enemies.ForEach(enemy => enemy.Killed -= OnEnemyKilled);
        }
    }
}
