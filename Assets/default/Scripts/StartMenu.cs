using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private TMPro.TextMeshProUGUI playModeText;

    public void OnClickStartButton()
    {
        GameManager.instance.Gamemode = "solo";
        playModeText.text = "PlayMode:" + GameManager.instance.Gamemode;
        startMenu.SetActive(false);
    }

    public void OnClickOnePlayerButton()
    {
        GameManager.instance.Gamemode = "1P";
        playModeText.text = "PlayMode:" + GameManager.instance.Gamemode;
        startMenu.SetActive(false);
    }

    public void OnClickTwoPlayerButton()
    {
        GameManager.instance.Gamemode = "2P";
        playModeText.text = "PlayMode:" + GameManager.instance.Gamemode;
        startMenu.SetActive(false);
    }

}
