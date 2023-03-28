using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using Scripts.Tool;
using ProtoBuf;
using SocketProtocol;

namespace Scripts.System
{
    public class ClientSystem : SystemManager
    {
        private Socket socket;
        private Message message;
        public ClientSystem(Main main):base(main){}

        public override void OnInit()
        {
            base.OnInit();
            message = new Message();
            InitSocket();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            message = null;
            CloseSocket();
        }
        private void InitSocket()//初始化socket连接
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//TCP连接
            try
            {
                socket.Connect("127.0.0.1", 23346);
                StartReceive();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        private void CloseSocket()//关闭socket连接
        {
            if(socket!=null && socket.Connected)
            {
                socket.Close();
            }
        }
        private void StartReceive()//开始接收消息
        {
            socket.BeginReceive(message.Buffer, message.StartIndex, message.Remsize, SocketFlags.None, ReceiveCallback,null);
        }
        private void ReceiveCallback(IAsyncResult iar)
        {
            try
            {
                if(socket == null || socket.Connected == false) return;
                int len = socket.EndReceive(iar);
                if(len == 0)
                {
                    CloseSocket();
                    return;
                }
                message.ReadBuffer(len, HandleResponce);
                StartReceive();
            }
            catch
            {
                
            }
        }
        private void HandleResponce(MainPack pack)
        {
            main.HandleResponce(pack);
        }
        public void Send(MainPack pack)
        {
            socket.Send(Message.PackData(pack));
        }
    }
}
