using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestStage : MonoBehaviour
{
    [SerializeField] private float _frontEdge;
    [SerializeField] private float _backEdge;
    [SerializeField] private float MoveSpeed = 0.5f;
    private float direction = 1.0f;

    

    private Rigidbody _coinStage;
    // Start is called before the first frame update
    void Start()
    {
        _coinStage=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
    void FixedUpdate()
    {
        
        
        if (transform.position.x >= _frontEdge)
            direction = -1;
        else if (transform.position.x <= _backEdge)
            direction = 1;
        Vector3 now=_coinStage.position;
        now += new Vector3 (MoveSpeed * Time.fixedDeltaTime * direction,0.0f,0.0f);
       _coinStage.MovePosition(now);
     
        //addforceのやり方
    //     _coinStage.AddForce(new Vector3 (direction*3f,0.0f,0.0f),ForceMode.Acceleration);
    
    }
}

