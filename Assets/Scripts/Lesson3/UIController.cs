using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Button buttonStartServer;
    [SerializeField]
    private Button buttonShutDownServer;
    [SerializeField]
    private Button buttonConnectClient;
    [SerializeField]
    private Button buttonDisconnectClient;
    [SerializeField]
    private Button buttonSendMessage;

    [SerializeField]
    private TMP_InputField inputField;


    [SerializeField]
    private TextField textField;

    [SerializeField]
    private Server server;
    [SerializeField]
    private Client client;

    [System.Obsolete]
    private void Start()
    {
        buttonStartServer.onClick.AddListener(() => StartServer());
        buttonShutDownServer.onClick.AddListener(() => ShutDownServer());
        buttonConnectClient.onClick.AddListener(() => Connect());
        buttonDisconnectClient.onClick.AddListener(() => Disconnect());
        buttonSendMessage.onClick.AddListener(() => SendMessage());
        client.onMessageReceive += ReceiveMessage;
    }

    [System.Obsolete]
    private void StartServer()
    {
        server.StartServer();
    }

    [System.Obsolete]
    private void ShutDownServer()
    {
        server.ShutDownServer();
    }

    [System.Obsolete]
    private void Connect()
    {
        client.Connect();
    }

    [System.Obsolete]
    private void Disconnect()
    {
        client.Disconnect();
    }

    [System.Obsolete]
    private void SendMessage()
    {
        client.SendMessage(inputField.text);
        inputField.text = "";
    }

    public void ReceiveMessage(object message)
    {
        textField.ReceiveMessage(message);
    }
}