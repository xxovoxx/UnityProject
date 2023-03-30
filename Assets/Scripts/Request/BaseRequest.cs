using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using SocketProtocol;
using Scripts.Request;

namespace Scripts.Request
{
    public class BaseRequest : MonoBehaviour//
    {
        protected Main main;
        protected RequestCode requestCode;
        protected ActionCode actionCode;
        public ActionCode GetActionCode
        {
            get
            {
                return actionCode;
            }
        }
        public virtual void Awake()
        {
            main = Main.GetMain;
        }
        public virtual void Start()
        {
            main.AddRequest(this);
        }

        public virtual void OnDestroy()
        {
            main.RemoveRequest(actionCode);
        }

        public virtual void OnResponse(MainPack pack)//接收请求
        {

        }
        public virtual void SendRequest(MainPack pack)
        {
            main.Send(pack);
        }
    }
}
