using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.Enums;

namespace Scripts.UI
{
    public class LoginPanel : BasePanel
    {
        public Button EnterRegisterButton;

        private void Start()
        {
            EnterRegisterButton.onClick.AddListener(OnEnterRegisterButtonClick);    
        }

        private void OnEnterRegisterButtonClick()
        {
            uiSystem.PushUI(UIType.Register);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Enter();
        }
        public override void OnExit()
        {
            base.OnExit();
            Exit();
        }
        public override void OnRecovery()
        {
            base.OnRecovery();
            Enter();
        }
        public override void OnPause()
        {
            base.OnPause();
            Exit();
        }

        private void Enter()
        {
            gameObject.SetActive(true);
        }
        private void Exit()
        {
            gameObject.SetActive(false);
        }
    }
}
