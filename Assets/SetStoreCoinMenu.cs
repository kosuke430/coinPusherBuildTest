using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStoreCoinMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject warningText;

    /// <summary>
    /// 貯玉のMenuを表示する
    /// </summary>
    public void SetCoinMenu()
    {
        menuPanel.SetActive(true);
        warningText.SetActive(false);
    }
}
