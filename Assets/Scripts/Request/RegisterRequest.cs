using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using SocketProtocol;
using Scripts.UI;

namespace Scripts.Request
{
    //注册请求
    public class RegisterRequest : BaseRequest
    {
        public RegisterPanel registerPanel;

        private MainPack pack = null;
        public override void Awake()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Register;
            base.Awake();
        }

        //将异步操作回归主线程
        private void Update()
        {
            if (pack != null)
            {
                registerPanel.OnResponse(pack);
                pack = null;
            }
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }
        public void SendRequest(string displayName, string account, string password)
        {
            MainPack pack = new MainPack();
            pack.requestCode = requestCode;
            pack.actionCode = actionCode;
            RegisterPack registerPack = new RegisterPack();
            registerPack.DisplayName = displayName;
            registerPack.Account = account;
            registerPack.Password = password;
            pack.registerPack = registerPack;
            base.SendRequest(pack);
        }
    }
}
