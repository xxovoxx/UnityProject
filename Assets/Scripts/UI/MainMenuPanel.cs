using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Scripts.Enums;

namespace Scripts.UI
{
    public class MainMenuPanel : BasePanel
    {
        public Button EnterRoomListButton;

        private void Start()
        {
            EnterRoomListButton.onClick.AddListener(OnEnterRoomListButtonClick);
        }

        private void OnEnterRoomListButtonClick()
        {
            uiSystem.PushUI(UIType.RoomList);
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
