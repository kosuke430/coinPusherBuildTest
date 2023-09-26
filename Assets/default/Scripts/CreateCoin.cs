using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoin : MonoBehaviour
{
    public static CreateCoin instance;
    [SerializeField] CoinController coinController;

    public Queue<CoinController> coinQueue;

    [SerializeField] private int _spawnCoinNum=0;
    // Start is called before the first frame update

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
        coinQueue=new Queue<CoinController>();
        makeCoin();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void makeCoin()
    {
        for (int i = 0; i < _spawnCoinNum; i++)
        {
            CoinController coin=Instantiate(coinController);
            coin.transform.SetParent(this.transform,false);
            coin.gameObject.SetActive(false);
            coinQueue.Enqueue(coin);
        }
    }

    public CoinController Launch(Vector3 _pos)
    {
        //Queueが空ならnull
        if (coinQueue.Count <= 0) return null;
        //Queueから弾を一つ取り出す
        CoinController coin = coinQueue.Dequeue();
        coin.transform.position=_pos;
        
        
        //呼び出し元に渡す
        return coin;
    }

    // public void Collect(CoinController _coin)
    // {
    //     _coin.gameObject.SetActive(false);
    //     _coin.transform.position=this.transform.position;
    //     _coin.transform.rotation=this.transform.rotation;
    //     //Queueに弾を戻す
    //     coinQueue.Enqueue(_coin);
    // }
}
