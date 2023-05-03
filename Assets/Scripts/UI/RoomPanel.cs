using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SocketProtocol;
using Scripts.Request;

namespace Scripts.UI
{
    public class RoomPanel : BasePanel
    {
        public Button BackToRoomListButton, SendChatButton;
        public TMP_InputField chatInput;
        public Scrollbar scrollbar;
        public Transform content;
        public GameObject userItem;

        private void Start()
        {
            BackToRoomListButton.onClick.AddListener(OnBackToRoomListButtonClick);
            SendChatButton.onClick.AddListener(OnSendChatButtonClick);
        }

        private void OnBackToRoomListButtonClick()
        {
            uiSystem.PopUI();
        }

        private void OnSendChatButtonClick()
        {

        }

        public void UpdatePlayerList(List<PlayerPack> players)
        {
            for(int i = 0; i < content.childCount; i++) 
            {
                Destroy(content.GetChild(i).gameObject);
            }
            foreach(PlayerPack playerPack in players)
            {
                PlayerItem item = Instantiate(userItem, content).GetComponent<PlayerItem>();
                item.SetPlayInfo(playerPack);
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Enter();
        }
        public override void OnExit()
        {
            base.OnExit();
            Exit();
        }
        public override void OnRecovery()
        {
            base.OnRecovery();
            Enter();
        }
        public override void OnPause()
        {
            base.OnPause();
            Exit();
        }

        private void Enter()
        {
            gameObject.SetActive(true);
        }
        private void Exit()
        {
            gameObject.SetActive(false);
        }
    }
}