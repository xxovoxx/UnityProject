using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using SocketProtocol;

namespace Scripts.Request
{
    public class RegisterRequest : BaseRequest//注册请求
    {
        public override void Awake()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Register;
            base.Awake();
        }

        public override void OnResponse(MainPack pack)
        {
            switch (pack.returnCode)
            {
                case ReturnCode.Succeed:
                    Debug.Log("注册成功");
                    break;
                case ReturnCode.Failed:
                    Debug.LogWarning("注册失败");
                    break;
            }
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
