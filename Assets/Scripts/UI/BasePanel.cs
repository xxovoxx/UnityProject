using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.System;
using SocketProtocol;

namespace Scripts.UI
{
    public class BasePanel : MonoBehaviour
    {
        protected UISystem uiSystem;
        public UISystem SetuiSystem
        {
            set
            {
                uiSystem = value;
            }
        }


        public virtual void OnEnter()//用于创建时初始化
        {

        }
        public virtual void OnExit()
        {

        }
        public virtual void OnRecovery()
        {

        }
        public virtual void OnPause()
        {

        }
    }
}
