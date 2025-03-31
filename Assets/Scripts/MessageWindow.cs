using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Message
{
    public string header;
    public string text;
    public string buttonText;

    public Message()
    {

    }

    public Message(string header, string text = "", string buttonText = "")
    {
        this.header = header;
        this.text = text;
        this.buttonText = buttonText;
    }
}

public delegate void ButtonFunc();

public class MessageWindow : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Button _button;
    [SerializeField] Image _background;
    [SerializeField] TextMeshProUGUI _headerText;
    [SerializeField] TextMeshProUGUI _messageText;
    [SerializeField] TextMeshProUGUI _buttonText;
    [SerializeField] Action _buttonFunc;


    public void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = FindAnyObjectByType<Camera>();
        canvas.planeDistance = 0;
        _buttonFunc = CloseMessageWindow;
    }

    public void ShowMessage(Message message)
    {
        ShowMessage(message, CloseMessageWindow);
    }


    public void ShowMessage(Message message, Action func)
    {
        _headerText.text = message.header;
        _messageText.text = message.text;
        _buttonText.text = message.buttonText;
        _buttonFunc = func;
    }

    public void OnButtonClick()
    {
        _buttonFunc?.Invoke();
    }

    public void CloseMessageWindow()
    {
        Destroy(gameObject);
    }

    public void OnDisable()
    {
        _buttonFunc = null;
    }
}
