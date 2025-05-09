using GameUI;
using UnityEngine;

namespace GameSystems
{
    public class ShowButton : GameAction
    {
        [SerializeField] private UIButton button;

        public override void Invoke()
        {
            base.Invoke();
            button.gameObject.SetActive(true);
        }
    }
}
