using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.System;
using ProtoBuf;
using SocketProtocol;
using Scripts.Request;

//主进程 用于调用各个系统
public class Main : MonoBehaviour
{
    private ClientSystem clientSystem;
    private RequestSystem requestSystem;
    private UISystem uiSystem;
    private static Main main;
    public static Main GetMain
    {
        get
        {
            if(main == null)
            {
                main = GameObject.Find("MainSystem").GetComponent<Main>();
            }
            return main;
        }
    }
    void Awake()
    {
        uiSystem = new UISystem(this);
        clientSystem = new ClientSystem(this);
        requestSystem = new RequestSystem(this);
        
        uiSystem.OnInit();
        clientSystem.OnInit();
        requestSystem.OnInit();
    }

    void OnDestroy()
    {
        clientSystem.OnDestroy();
        requestSystem.OnDestroy();
        uiSystem.OnDestroy();
    }
    

    public void Send(MainPack pack)
    {
        clientSystem.Send(pack);
    }
    public void HandleResponce(MainPack pack)
    {
        requestSystem.HandleResponse(pack);
    }


    public void AddRequest(BaseRequest request)
    {
        requestSystem.AddRequest(request);
    }
    public void RemoveRequest(ActionCode action)
    {
        requestSystem.RemoveRequest(action);
    }

    public void ShowMessage(string str, bool isSync = false)
    {
        uiSystem.ShowMessage(str, isSync);
    }
}