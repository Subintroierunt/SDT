using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(ButtonClicked);
        }

        public virtual void ButtonClicked()
        {

        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
