using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.Request;

namespace Scripts.UI
{
    public class RegisterPanel : BasePanel
    {
        public RegisterRequest registerRequest;
        public TMP_InputField displayName, account, password;
        public Button RegisterButton, EnterLoginButton;
        private void Start()
        {
            RegisterButton.onClick.AddListener(OnRegisterClick);
            EnterLoginButton.onClick.AddListener(EnterLogin);
        }
        private void OnRegisterClick()
        {
            if(displayName.text == "" || account.text == "" || password.text =="")
            {
                Debug.LogWarning("显示名、用户名、密码不得为空");
                return;
            }
            registerRequest.SendRequest(displayName.text, account.text, password.text);
        }

        private void EnterLogin()
        {
            uiSystem.PopUI();
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