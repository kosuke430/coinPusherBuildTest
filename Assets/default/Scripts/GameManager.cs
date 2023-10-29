using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // シングルトン

    //獲得コインを表示するテキスト
    [SerializeField] private TMPro.TextMeshProUGUI coinCountText;
    //貯玉の総数を表示するテキスト
    [SerializeField] private TMPro.TextMeshProUGUI AllStoreCoinText;

    [SerializeField] public List<TMPro.TextMeshProUGUI> RankingNameTexts;

    [SerializeField] public List<TMPro.TextMeshProUGUI> RankinghaveCoinTexts;

    /// <summary>
    /// solo,1P,2Pのいづれかを入れる
    /// </summary>
    public string Gamemode;

    private int getCoinCount=0;

    public int GetCoinCount
    {
        get => getCoinCount;
        set => getCoinCount = value;
    }


   void Awake()
    {
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
        

    }

    void Start()
    {
        //獲得メダル初期化
        coinCountText.text="GetCoin:\n0coin";

        //貯玉の総数の表示
        // AllStoreCoinText.text="AllStoreCoin:\n"+NetWorkManager.instance.testUser.haveCoin.ToString()+"coins";
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text="GetCoin:\n"+getCoinCount.ToString()+"coins";

         AllStoreCoinText.text="AllStoreCoin:\n"+NetWorkManager.instance.testUser.haveCoin.ToString()+"coins";
    }

    public void AddGetCoinCount()
    {
        getCoinCount++;
        // coinCountText.text="GetCoin:\n"+getCoinCount.ToString()+"coins";
        Debug.Log($"getCoinCount:{getCoinCount}");
    }

    /// <summary>
    /// 貯玉した時の獲得コインを更新してUI表示を更新する 
    /// </summary>
    /// <param name="AddStoreCoinNum"></param> <summary>
    /// 
    /// </summary>
    /// <param name="AddStoreCoinNum"></param>
    public void UpdateGetCoinCount(int AddStoreCoinNum)
    {
        getCoinCount-=AddStoreCoinNum;
    }

    
}
