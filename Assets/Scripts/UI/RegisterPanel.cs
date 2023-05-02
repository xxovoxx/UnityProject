using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.Request;
using SocketProtocol;

namespace Scripts.UI
{
    public class RegisterPanel : BasePanel
    {
        public RegisterRequest registerRequest;
        public TMP_InputField displayName, account, password;
        public Button RegisterButton, EnterLoginButton;

        private void Start()
        {
            RegisterButton.onClick.AddListener(OnRegisterButtonClick);
            EnterLoginButton.onClick.AddListener(OnEnterLoginButtonClick);
        }
        private void OnRegisterButtonClick()
        {
            if(displayName.text == "" || account.text == "" || password.text =="")
            {
                Debug.LogWarning("显示名、用户名、密码不得为空");
                uiSystem.ShowMessage("显示名、用户名、密码不得为空!", true);
                return;
            }
            registerRequest.SendRequest(displayName.text, account.text, password.text);
        }

        public void OnResponse(MainPack pack)
        {
            switch (pack.returnCode)
            {
                case ReturnCode.Succeed:
                    Debug.Log("注册成功");
                    uiSystem.ShowMessage("注册成功!可以进行登录了");
                    uiSystem.PopUI();
                    break;
                case ReturnCode.Failed:
                    Debug.LogWarning("注册失败!");
                    uiSystem.ShowMessage("注册失败!该账号可能已被注册");
                    break;
            }
        }

        private void OnEnterLoginButtonClick()
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