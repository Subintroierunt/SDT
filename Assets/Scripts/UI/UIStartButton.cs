using GameSystems;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class UIStartButton : UIButton
    {
        [SerializeField] private List<GameAction> actions;

        public override void ButtonClicked()
        {
            base.ButtonClicked();
            actions.ForEach(action => action.Invoke());
            gameObject.SetActive(false);
        }
    }
}
