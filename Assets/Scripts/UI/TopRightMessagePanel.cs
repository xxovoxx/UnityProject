using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.UI
{
    public class TopRightMessagePanel : BasePanel
    {
        RectTransform rectTransform;
        public TMP_Text text;
        string msg = null;

        void Update()
        {
            if(msg != null)
            {
                ShowText(msg);
                msg = null;
            }
        }

        //显示消息，第二个传入参数是是否为异步消息
        public void ShowMessage(string str, bool isSync = false)
        {
            if(isSync)
            {
                //异步显示
                msg = str;
            }
            else
            {
                ShowText(str);
            }
        }

        private void ShowText(string str)
        {
            text.text = str;
            Show();
            Invoke("Hide",5);
        }

        public override void OnEnter()
        {
            base.OnEnter();
            rectTransform = gameObject.GetComponent<RectTransform>();
            Hide();
            uiSystem.SetTopRightMessagePanel(this);
        }
        public override void OnExit()
        {
            base.OnExit();
        }
        public override void OnRecovery()
        {
            base.OnRecovery();
        }
        public override void OnPause()
        {
            base.OnPause();
        }

        private void Show()
        {
            this.CancelInvoke();
            rectTransform.localScale = new Vector3(1,1,1);
        }
        private void Hide()
        {
            rectTransform.localScale = new Vector3(0,0,0);
        }
    }
}