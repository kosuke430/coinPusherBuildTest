using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOutCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log($"回収物:{other.gameObject.name}");
            other.transform.position=new Vector3(0,0,0);
            other.transform.rotation=Quaternion.Euler(0,0,0);

            Transform coinParent=other.transform;
            coinParent.gameObject.SetActive(false);
            
            // other.transform.parent.SetParent(null,true);
            // CreateCoin.instance.Collect(coinParent.GetComponent<CoinController>());
            CheckRecycleCoin.instance.recycleCoinQueue.Enqueue(coinParent.GetComponent<CoinController>());
            Debug.Log($"coinCount:{ CheckRecycleCoin.instance.recycleCoinQueue.Count}");
        }
    }
}
