using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketProtocol;
using Scripts.System;
using Scripts.Enums;
using UnityEngine.Rendering.VirtualTexturing;
using Scripts.Request;

namespace Scripts.UI
{
    public class RoomItem : MonoBehaviour
    {
        public RoomListPanel roomListPanel;

        public Button JoinButton;
        public TMP_Text title, num, state;
        private int roomID;

        private void Start()
        {
            JoinButton.onClick.AddListener(OnJoinButtonClick);
        }

        private void OnJoinButtonClick()
        {
            roomListPanel.JoinRoom(roomID);
        }

        public void SetRoomInfo(RoomPack roomPack)
        {
            this.title.text = roomPack.RoomName;
            this.num.text = roomPack.CurrentNum + "/" + roomPack.MaxNum;
            this.roomID = roomPack.Id;

            switch (roomPack.roomState)
            {
                case RoomState.InGame:
                    this.state.text = "InGame";
                    break;
                case RoomState.OutOfGame:
                    this.state.text = "OutOFGame";
                    break;
            }
        }
    }
}
