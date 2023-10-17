using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetWorkManager : MonoBehaviour
{
    public static NetWorkManager instance; // シングルトン

    [System.Serializable]
    public class JsonData
    {
        public UserInfo[] userInfos;
    }

    [System.Serializable]
    public class UserInfo 
    {
        public long id;
        public string? name;
        public int haveCoin;

        public int ranking;   
    }
    private string apiUrl="http://localhost:5263/api/CoinUserss";

    
    private int thisUserID=1;

    public UserInfo testUser= new UserInfo();
    // Start is called before the first frame update



    void Awake()
    {
        //シングルトンの実装とテストデータの初期化
        if (instance == null)
        {
            // 自身をインスタンスとする
            instance = this;
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する
            Destroy(gameObject);
        }


        testUser.id=5;
        GetMethod();
    }

    public void UpdateHaveMedal(int addMedal)
    {
        GameManager.instance.UpdateGetCoinCount(addMedal);
        testUser.haveCoin+=addMedal;
        Debug.Log($"testUser.haveMedals:{testUser.haveCoin}");
        PutMethod();
    }

    void Start()
    {
    }
    
    /// <summary>
    /// User情報をサーバーから取得する
    /// </summary> <summary>
    /// 
    /// </summary>
    void GetMethod()
    {
        Debug.Log(testUser.id);
        StartCoroutine(GetText(apiUrl));
    }

    /// <summary>
    /// 貯玉をサーバーに送信する
    /// </summary>
    void PostMethod()
    {
        string json = JsonUtility.ToJson(testUser);
        StartCoroutine(PostRequest(apiUrl,json));
    }

    void PutMethod()
    {
        string json = JsonUtility.ToJson(testUser);
        StartCoroutine(PutStoreCoin(apiUrl,json));
    }


    /// <summary>
    /// ユーザー情報をidから取得する
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator GetText(string url) 
    {
        UnityWebRequest www = UnityWebRequest.Get(url+"/"+testUser.id);
        // UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // 結果をテキストで表示
            Debug.Log("受け取り成功");
            JsonData jsonData = new JsonData();
            //idをキーにして取得する場合は　[]で囲む
            string catchData="{ \"userInfos\":["+www.downloadHandler.text+"]}";
            Debug.Log(catchData);
            JsonUtility.FromJsonOverwrite(catchData,jsonData);
            Debug.Log($"jsonData:{jsonData}");
            Debug.Log(www.downloadHandler.text);
            foreach (var item in jsonData.userInfos)
            {
                testUser.name=item.name;
                testUser.haveCoin=item.haveCoin;
                testUser.ranking=item.ranking;
                Debug.Log("id: " + testUser.id);
                Debug.Log("name: " + testUser.name);
                Debug.Log("haveCoin: " + testUser.haveCoin);
            }


            
        }
    }


    /// <summary>
    /// メダルの更新をpostする
    /// </summary>
    /// <param name="url"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    IEnumerator PostRequest(string url, string json)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
 
        Debug.Log("Response: " + request.downloadHandler.text);

        if (request.isNetworkError ||request.isHttpError)  // 失敗
        {
            Debug.Log("Network error:" + request.error);
        }
        else                  // 成功
        {
            Debug.Log("Succeeded:" + request.downloadHandler.text);
        }
    }

    IEnumerator PutStoreCoin(string url,string json)
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
        
        UnityWebRequest www = UnityWebRequest.Put(url+"/"+testUser.id, myData);
        //putも以下3行の用にbufferに書き込む必要がある
        www.uploadHandler = (UploadHandler) new UploadHandlerRaw(myData);
        www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
        
    }


}
