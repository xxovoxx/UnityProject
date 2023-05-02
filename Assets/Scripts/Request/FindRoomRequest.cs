using Scripts.UI;
using SocketProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Request
{
    public class FindRoomRequest : BaseRequest
    {
        public RoomListPanel roomListPanel;

        private MainPack pack = null;
        public override void Awake()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.FindRoom;
            base.Awake();
        }

        //将异步操作回归主线程
        private void Update()
        {
            if (pack != null)
            {
                roomListPanel.FindRoomResponse(pack);
                pack = null;
            }
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }

        public void SendRequest()
        {
            MainPack pack = new MainPack();
            pack.requestCode = requestCode;
            pack.actionCode = actionCode;
            //防止包为空发不出去的字符串
            pack.Str = "CreateRoom";
            base.SendRequest(pack);
        }
    }
}