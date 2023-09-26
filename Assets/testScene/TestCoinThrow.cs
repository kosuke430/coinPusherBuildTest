using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoinThrow : MonoBehaviour
{
    [SerializeField] private GameObject _testCoin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_testCoin, transform.position, Quaternion.identity);
        }
            
    }
}
