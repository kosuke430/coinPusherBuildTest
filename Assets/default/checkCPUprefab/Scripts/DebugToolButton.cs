using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugToolButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject debugTool;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time.deltaTime:"+Time.deltaTime);
    }

    public void OnClick()
    {
        if (debugTool.activeSelf)
            debugTool.SetActive(false);
        else
            debugTool.SetActive(true);

        Debug.Log("押された");
    }
    
}
