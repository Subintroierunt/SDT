using Entities;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider hpBar;
        [SerializeField] private Transform target;
        [SerializeField] private CharacterHealth health;
        [SerializeField] private Vector2 offset;

        private void Start()
        {
            health.DamageTaked += ChangeHealthView;
        }

        private void Update()
        {
            hpBar.transform.position = Camera.main.WorldToScreenPoint(target.transform.position + (Vector3)offset);
        }

        private void ChangeHealthView(float value)
        {
            hpBar.value = value;
        }

        private void OnDestroy()
        {
            health.DamageTaked -= ChangeHealthView;
        }
    }
}
