using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Enums;
using Scripts.UI;

namespace Scripts.System
{
    public class UISystem : SystemManager
    {
        public UISystem(Main main):base(main){}

        private Dictionary<UIType, BasePanel> uiDict = new Dictionary<UIType, BasePanel>();//储存生成出来的UI
        private Dictionary<UIType, string> uiPath = new Dictionary<UIType, string>();//储存预制体的地址
        private Stack<BasePanel> uiStack = new Stack<BasePanel>();//用堆栈来管理UI的显示
        private Transform canvaTransform;//用于获取场景里的画布对象的位置

        public override void OnInit()
        {
            base.OnInit();
            InitUI();
            canvaTransform = GameObject.Find("Canvas").transform;
            PushUI(UIType.Login);
        }

        public void PushUI(UIType ui)//显示ui
        {
            if(uiDict.TryGetValue(ui, out BasePanel panel))//看看有没有生成过这个UI
            {
                if(uiStack.Count > 0)//看堆栈里有没有UI，有的话就把上一个UI暂停了
                {
                    BasePanel topPanel = uiStack.Peek();
                    topPanel.OnPause();
                }

                uiStack.Push(panel);
                panel.OnEnter();
            }
            else
            {
                SpawnUI(ui);
                PushUI(ui);
            }
        }

        public  void PopUI()//关闭UI
        {
            if(uiStack.Count == 0) return;
            BasePanel topPanel = uiStack.Pop();
            topPanel.OnExit();

            BasePanel panel = uiStack.Peek();
            panel.OnRecovery();
        }

        private BasePanel SpawnUI(UIType ui)//实例化
        {
            if(uiPath.TryGetValue(ui, out string path))
            {
                GameObject gameObject = GameObject.Instantiate(Resources.Load<GameObject>(path), canvaTransform);//生成设定路径的预制体，父对象为Canvas，同时把生成的这个物体让gameObject表示
                BasePanel tmp = gameObject.GetComponent<BasePanel>();
                uiDict.Add(ui, tmp);
                tmp.SetuiSystem = this;
                return tmp;
            }
            else
            {
                return null;
            }
        }

        private void InitUI()//添加UI预制体的文件路径
        {
            string folderPath = "Prefab/UI/";
            uiPath.Add(UIType.Login, folderPath + "Login");
            uiPath.Add(UIType.Register, folderPath + "Register");
            uiPath.Add(UIType.MainMenu, folderPath + "MainMenu");
            uiPath.Add(UIType.TopRightMessage, folderPath + "TopRightMessage");
        }
    }
}
