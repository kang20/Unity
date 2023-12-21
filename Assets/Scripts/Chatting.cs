using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chatting : MonoBehaviour
{
    public InputField _InputField;
    public Text Chat;
    public PlayerMovement Pm;
    public CameraMovement Cm;

    public FromReact FReact;
    // Start is called before the first frame update
    private void Start()
    {
        _InputField.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        _InputField.ActivateInputField();
        //Debug.Log("포커스 1 enabled" + _InputField.enabled);
        //Debug.Log("포커스 2 focus" + _InputField.isFocused);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_InputField.enabled)
            {
                string Chatt = _InputField.text;
                _InputField.text = "";
                if (Chatt != "")
                {
                    FReact.ChatfromUnity(LocalPlayerManager.instance.Nickname, Chatt);
                }
                //Chat.text += LocalPlayerManager.instance.Nickname + ":" + Chatt + "\n";
                _InputField.enabled = false;
                Pm.enabled = true;
                Cm.isESC = false;
                Cm.enabled = true;
            }
            else
            {
                _InputField.enabled = true;
                Pm.enabled = false;
                Cm.enabled = false;
            }
        }
    }
    public void PrintText(string str)
    {
        Chat.text += str + "\n";
    }
}