using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoinScript : MonoBehaviour
{
    public static Vector3 screenPos; 
    public static Vector3 worldPos;

    private CoinController _coin;

    [SerializeField] private float throwTime=0.5f;

    [SerializeField] private int onePushSpawn=50;

    [SerializeField] private GameObject coinParent; 
    private float timeElapsed;


    [SerializeField] private GameObject centerStage;

    
    [SerializeField] private GameObject coinPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed > throwTime) 
        {
           if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
            {
                
                var distance = Vector3.Distance(centerStage.transform.position, Camera.main.transform.position);
                screenPos=new Vector3(Input.mousePosition.x,Input.mousePosition.y,distance);
                worldPos = Camera.main.ScreenToWorldPoint(screenPos);

                Vector3 fixWorldPos = new Vector3 (-1.0f,5.0f,worldPos.z);

                // Debug.Log(screenPos);
                Debug.Log(fixWorldPos);
                //Quaternion.identityは回転させないという意味
                // _coin=Instantiate(coinPrefab, fixWorldPos, Quaternion.identity);
                _coin=CreateCoin.instance.Launch(fixWorldPos);
                _coin.gameObject.SetActive(true);
                // _coin.transform.SetParent(coinParent.transform);
                _coin.transform.rotation=Quaternion.Euler(Random.Range(0,70),Random.Range(0,30),Random.Range(0,70));

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    for (var i=0;i<onePushSpawn-1;++i)
                    {
                        // _coin=CreateCoin.instance.Launch(fixWorldPos);
                        // _coin.gameObject.SetActive(true);
                        // _coin.transform.rotation=Quaternion.Euler(Random.Range(0,70),Random.Range(0,30),Random.Range(0,70));
                        ClickTestCoinAdd();
                    }
                }
                
                timeElapsed = 0.0f;
            }
        }
        else
        {
             timeElapsed += Time.deltaTime;
        }
        

        
    }

    public void ClickTestCoinAdd()
    {
        for (var i=0;i<onePushSpawn-1;++i)
        {
            //3.5~-1.8
            float _randPositionY=Random.Range(5,7);
            float _randPositionX=Random.Range(-2,3);
            float _randAddPositionZ=Random.Range(-4,4);
            Vector3 _addCoinPosition=new Vector3(_randPositionX,_randPositionY,centerStage.transform.position.z+_randAddPositionZ);  
            // Vector3 _addCoinPosition=new Vector3(-1.0f,5.0f,centerStage.transform.position.z);  
            _coin=CreateCoin.instance.Launch(_addCoinPosition);
            _coin.transform.rotation=Quaternion.Euler(Random.Range(0,70),Random.Range(0,30),Random.Range(0,70));
            _coin.gameObject.SetActive(true);
        }
    }
}
