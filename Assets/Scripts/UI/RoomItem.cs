using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketProtocol;
using Scripts.System;

public class RoomItem : MonoBehaviour
{
    public Button JoinButton;
    public TMP_Text title, num, state;

    private void Start()
    {
        JoinButton.onClick.AddListener(OnJoinButtonClick);
    }

    private void OnJoinButtonClick()
    {

    }

    public void SetRoomInfo(RoomPack roomPack)
    {
        this.title.text = roomPack.RoomName;
        this.num.text = roomPack.CurrentNum + "/" + roomPack.MaxNum;

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
