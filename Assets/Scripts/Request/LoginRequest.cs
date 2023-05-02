using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using Scripts.UI;

namespace Scripts.Request
{
    public class LoginRequest : BaseRequest
    {
        public LoginPanel loginPanel;

        private MainPack pack = null;
        public override void Awake()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Login;
            base.Awake();
        }

        private void Update()
        {
            if (pack != null)
            {
                loginPanel.OnResponse(pack);
                pack = null;
            }
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }

        public void SendRequest(string account, string password)
        {
            MainPack pack = new MainPack();
            pack.requestCode = requestCode;
            pack.actionCode = actionCode;
            LoginPack loginPack = new LoginPack();
            loginPack.Account = account;
            loginPack.Password = password;
            pack.loginPack = loginPack;
            
            base.SendRequest(pack);
        }
    }
}
