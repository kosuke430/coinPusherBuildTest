using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddStoreCoin : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    
    
 
    // Start is called before the first frame update
    void Start()
    {
       
    }
 
 
    public void GetInputName()
    {
        int coinNum = int.Parse(this.inputField.text);

        if (GameManager.instance.GetCoinCount>=coinNum)
        {
            //InputFieldからテキスト情報から獲得コイン数を取得する
            NetWorkManager.instance.UpdateHaveMedal(coinNum);
            Debug.Log(coinNum);
            //入力フォームのテキストを空にする
            inputField.text = "";
        } 
        else
        {   
            Debug.Log("獲得コイン数が足りません");
        }
    }
}
