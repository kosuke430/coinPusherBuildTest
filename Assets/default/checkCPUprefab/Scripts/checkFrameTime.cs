using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class checkFrameTime : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private TMPro.TMP_Text frameRateText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameRateText.text = "FrameTime:"+Time.deltaTime;
    }
}
