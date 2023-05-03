using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using Scripts.UI;

namespace Scripts.Request
{
    //房间信息请求
    public class RoomPlayerListRequest : BaseRequest
    {
        private MainPack pack = null;
        public RoomPanel roomPanel;
        public override void Awake()
        {
            actionCode = ActionCode.PlayerList;
            base.Awake();
        }

        private void Update()
        {
            if (pack != null)
            {
                roomPanel.UpdatePlayerList(pack.playerPacks);
                pack = null;
            }
        }

        public override void OnResponse(MainPack pack)
        {
            this.pack = pack;
        }

        public override void SendRequest(MainPack pack)
        {
            base.SendRequest(pack);
        }


    }
}