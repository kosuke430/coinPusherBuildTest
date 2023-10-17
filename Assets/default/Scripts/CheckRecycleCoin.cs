using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRecycleCoin : MonoBehaviour
{
    public static CheckRecycleCoin instance; // シングルトン

    public Queue<CoinController> recycleCoinQueue;

    // [SerializeField] private GameObject objectPool;

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

        recycleCoinQueue=CreateCoin.instance.coinQueue;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log($"回収物:{other.gameObject.name}");
            other.transform.position=new Vector3(0,0,0);
            other.transform.rotation=Quaternion.Euler(0,0,0);

            Transform coinParent=other.transform;
            coinParent.gameObject.SetActive(false);
            //獲得コインをカウントする
            GameManager.instance.AddGetCoinCount();
            // other.transform.parent.SetParent(null,true);
            // CreateCoin.instance.Collect(coinParent.GetComponent<CoinController>());
            recycleCoinQueue.Enqueue(coinParent.GetComponent<CoinController>());
            Debug.Log($"coinCount:{recycleCoinQueue.Count}");
        }
    }
}
