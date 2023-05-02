using Scripts.UI;
using SocketProtocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Request
{
    public class CreateRoomRequest : BaseRequest
    {
        public RoomListPanel roomListPanel;

        private MainPack pack = null;
        public override void Awake()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.CreateRoom;
            base.Awake();
        }

        //将异步操作回归主线程
        private void Update()
        {
            if (pack != null)
            {
                roomListPanel.CreateRoomResponse(pack);
                pack = null;
            }
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }

        public void SendRequest(string roomName,int maxNum)
        {
            MainPack pack = new MainPack();
            pack.requestCode = requestCode;
            pack.actionCode = actionCode;
            RoomPack room= new RoomPack();
            room.RoomName = roomName;
            room.MaxNum = maxNum;
            pack.roomPacks.Add(room);
            base.SendRequest(pack);
        }
    }
}
