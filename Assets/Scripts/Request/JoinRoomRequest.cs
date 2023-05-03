using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using Scripts.UI;

namespace Scripts.Request
{
    public class JoinRoomRequest : BaseRequest
    {
        public RoomListPanel roomListPanel;

        private MainPack pack = null;

        public override void Awake()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.JoinRoom;
            base.Awake();
        }

        private void Update()
        {
            if (pack != null)
            {
                roomListPanel.JoinResponse(pack);
                pack = null;
            }
        }

        public void SendRequest(int roomID)
        {
            MainPack pack = new MainPack();
            pack.requestCode = requestCode;
            pack.actionCode = actionCode;
            pack.Str = roomID.ToString();
            base.SendRequest(pack);
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }
    }
}