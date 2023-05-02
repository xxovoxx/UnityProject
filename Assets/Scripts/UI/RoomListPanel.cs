using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.Request;
using SocketProtocol;
using Scripts.Enums;
using Unity.VisualScripting;

namespace Scripts.UI
{
    public class RoomListPanel : BasePanel
    {
        public CreateRoomRequest createRoomRequest;
        public FindRoomRequest findRoomRequest;
        public Button EnterMainMenuButton, CreateRoomButton, RefreshButton;
        public Transform roomList;
        public GameObject roomItem;

        public TMP_Text roomPlayerNumDisplay;
        public Slider roomPlayerNum;
        public TMP_InputField roomName;

        private void Start()
        {
            EnterMainMenuButton.onClick.AddListener(OnEnterMainMenuClick);
            CreateRoomButton.onClick.AddListener(OnCreateRoomClick);
            RefreshButton.onClick.AddListener(OnRefreshButtonClick);
        }

        private void Update()
        {
            roomPlayerNumDisplay.text = "" + roomPlayerNum.value;
        }

        private void OnCreateRoomClick()
        {
            if(roomName.text == "")
            {
                uiSystem.ShowMessage("房间名不能为空!");
                return;
            }
            createRoomRequest.SendRequest(roomName.text, (int)roomPlayerNum.value);
        }

        private void OnRefreshButtonClick()
        {
            findRoomRequest.SendRequest();
        }

        public void CreateRoomResponse(MainPack pack)
        {
            switch (pack.returnCode)
            {
                case ReturnCode.Succeed:
                    Debug.Log("创建房间成功");
                    uiSystem.ShowMessage("创建房间成功!");
                    uiSystem.PushUI(UIType.Room);
                    break;
                case ReturnCode.Failed:
                    Debug.LogWarning("创建房间失败!");
                    uiSystem.ShowMessage("创建房间失败，请重试!");
                    break;
            }
        }

        public void FindRoomResponse(MainPack pack) 
        {
            switch (pack.returnCode)
            {
                case ReturnCode.Succeed:
                    Debug.Log("查询房间成功");
                    uiSystem.ShowMessage("查询房间成功!查询到"+pack.roomPacks.Count+"个房间");
                    UpdateRoomList(pack.roomPacks);
                    break;
                case ReturnCode.Failed:
                    Debug.LogWarning("查询房间失败!");
                    uiSystem.ShowMessage("查询房间失败，请重试!");
                    break;
            }
        }

        private void UpdateRoomList(List<RoomPack> rooms)
        {
            //清空房间列表
            for(int i = 0 ; i < roomList.childCount; i++)
            {
                Destroy(roomList.GetChild(i).gameObject);
            }
            //
            foreach(RoomPack roomPack in rooms) 
            {
                RoomItem item = Instantiate(roomItem, roomList).GetComponent<RoomItem>();
                item.SetRoomInfo(roomPack);
            }
        }

        private void OnEnterMainMenuClick()
        {
            uiSystem.PopUI();
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