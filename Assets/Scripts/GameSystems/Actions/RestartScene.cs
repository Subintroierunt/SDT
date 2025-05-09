using Entities;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class RestartScene : GameAction
    {
        [Tooltip("If off you need manualy put enemies into list")]
        [SerializeField] private bool useAutoDetect = true;
        [SerializeField] private List<CharacterHealth> enemies = new List<CharacterHealth>();
        [SerializeField] private Transform map;
        [SerializeField] private CharacterMove player;
        [SerializeField] private GameObject startButton;

        private void Start()
        {
            if (useAutoDetect)
            {
                enemies.Clear();
                map.GetComponentsInChildren(enemies);
            }
        }

        public override void Invoke()
        {
            base.Invoke();
            startButton.SetActive(true);
            player.Init(0);
            enemies.ForEach(e => e.Resurect());
        }
    }
}
