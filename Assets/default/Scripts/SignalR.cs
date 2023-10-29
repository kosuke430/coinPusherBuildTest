using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Concurrent;
using UnityEngine.SceneManagement;
using System;

public class SignalR : MonoBehaviour
{
    

    private readonly ConcurrentQueue<Action> _action = new ConcurrentQueue<Action>(); 
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
            //同期するコインの座標を受け取る
            Debug.Log("ReceiveCoinPosition");
            Vector3 _addCoinPosition=new Vector3(x,y,z);
            Debug.Log(_addCoinPosition);
            Debug.Log(sender);
            

            _action.Enqueue(() => ThrowCoinScript.instance.SetCoinAsync(_addCoinPosition));

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
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     connection.InvokeAsync("SendMessage", "Unity", "Hello");
        //     Debug.Log("Send");
        // }

        // foreach(var message in messages)
        // {
        //     Debug.Log(message);
        // }

        // Work the dispatched actions on the Unity main thread
    while(_action.Count > 0)
    {
        if(_action.TryDequeue(out var action))
        {
            action?.Invoke();
        }
    }


    }

    public void SendCoinPosition(float x,float y,float z,string sender)
    {
        connection.InvokeAsync("SendCoinPosition", x,y,z,sender);
    }

    
    




}
