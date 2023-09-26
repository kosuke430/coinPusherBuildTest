using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class checkFPS : MonoBehaviour
{
    //フレームレートチェック
    //参考 https://ekulabo.com/frame-rate-time
    public TMPro.TMP_Text fpsText;// フレームレートを表示するテキストです。   
    private int frameCount;// Update()が呼ばれた回数をカウントします。   
    private float elapsedTime;// 前回フレームレートを表示してからの経過時間です。
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 呼ばれた回数を加算します。
        frameCount++;

        // 前のフレームからの経過時間を加算します。
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1.0f)
        {
            // 経過時間が1秒を超えていたら、フレームレートを計算します。
            float fps = 1.0f * frameCount / elapsedTime;

            // 計算したフレームレートを画面に表示します。(小数点以下2ケタまで)
            string fpsRate = $"FPS: {fps.ToString("F2")}";
            fpsText.SetText(fpsRate);

            // フレームのカウントと経過時間を初期化します。
            frameCount = 0;
            elapsedTime = 0f;
        }
    }
    
}
