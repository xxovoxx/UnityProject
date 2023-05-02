using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.Enums;
using SocketProtocol;
using Scripts.Request;

namespace Scripts.UI
{
    public class LoginPanel : BasePanel
    {
        public LoginRequest loginRequest;
        public TMP_InputField account, password;
        public Button LoginButton, EnterRegisterButton;

        private void Start()
        {
            LoginButton.onClick.AddListener(OnLoginButtonClick);
            EnterRegisterButton.onClick.AddListener(OnEnterRegisterButtonClick);    
        }

        private void OnLoginButtonClick()
        {
            if(account.text =="" || password.text == "")
            {
                Debug.LogWarning("用户名、密码不得为空");
                uiSystem.ShowMessage("用户名、密码不得为空!", true);
                return;
            }
            loginRequest.SendRequest(account.text, password.text);
        }

        private void OnEnterRegisterButtonClick()
        {
            uiSystem.PushUI(UIType.Register);
        }

        public void OnResponse(MainPack pack)
        {
            switch (pack.returnCode)
            {
                case ReturnCode.Succeed:
                    Debug.Log("登录成功");
                    uiSystem.ShowMessage("登录成功!");
                    uiSystem.PushUI(UIType.MainMenu);
                    break;
                case ReturnCode.Failed:
                    Debug.LogWarning("登录失败!请检查账号密码是否正确!");
                    uiSystem.ShowMessage("登录失败!请检查账号密码是否正确!");
                    break;
            }
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
