using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;

public class SignalR : MonoBehaviour
{
    

    public static SignalR instance;
   public HubConnection connection;

   private List<string> messages = new List<string>();

    //シングルトンを使う
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {   
            Destroy(gameObject);
        }
        

    }

    async void Start()
    {
        connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5263/chatHub")
                .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var encodedMsg = $"{user}: {message}";
            messages.Add(encodedMsg);
        });
        connection.On<float,float,float,string>("ReceiveCoinPosition",(x, y,z,sender) =>
        {
            Debug.Log("ReceiveCoinPosition");
            Debug.Log(x);
            Debug.Log(y);
            Debug.Log(z);
            Debug.Log(sender);
            ThrowCoinScript.instance.SetCoinAsync(x,y,z);
        });

        await connection.StartAsync();
        Debug.Log(connection.State);


        
       
    }

    /// <summary>
    /// 受け取ったメッセージを表示する
    /// </summary> <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            connection.InvokeAsync("SendMessage", "Unity", "Hello");
            Debug.Log("Send");
        }

        foreach(var message in messages)
        {
            Debug.Log(message);
        }
    }

    public void SendCoinPosition(float x,float y,float z,string sender)
    {
        connection.InvokeAsync("SendCoinPosition", x,y,z,sender);
    }

    




}
