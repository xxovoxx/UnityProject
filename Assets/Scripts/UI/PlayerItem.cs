using SocketProtocol;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text displayerName, UID;

    public void SetPlayInfo(PlayerPack playerPack)
    {
        this.displayerName.text = playerPack.DisplayName;
        this.UID.text = "UID:" + playerPack.Uid.ToString();
    }
}