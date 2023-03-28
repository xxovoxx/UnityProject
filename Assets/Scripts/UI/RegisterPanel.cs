using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterPanel : MonoBehaviour
{
    public RegisterRequest registerRequest;
    public TMP_InputField displayName, account, password;
    public Button RegisterButton;
    private void Start()
    {
        RegisterButton.onClick.AddListener(OnRegisterClick);
    }
    private void OnRegisterClick()
    {
        if(displayName.text == "" || account.text == "" || password.text =="")
        {
            Debug.LogWarning("显示名、用户名、密码不得为空");
            return;
        }
        registerRequest.SendRequest(displayName.text, account.text, password.text);
    }
}
