using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using SocketProtocol;

namespace Scripts.System
{
    public class RequestSystem : SystemManager//管理所有的System
    {
        
        public RequestSystem(Main main) : base(main){}
        private Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();//用字典管理request
        public void AddRequest(BaseRequest request)
        {
            requestDict.Add(request.GetActionCode, request);
        }

        public void RemoveRequest(ActionCode action)
        {
            requestDict.Remove(action);
        }

        public void HandleResponse(MainPack pack)
        {
            if(requestDict.TryGetValue(pack.actionCode, out BaseRequest request))
            {
                request.OnResponse(pack);
            }
            else
            {
                Debug.LogWarning("找不到对应的处理");
            }
        }
    }
}
