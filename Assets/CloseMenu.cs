using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    // Start is called before the first frame update
    public void onClickCloseButton()
    {
        menuPanel.SetActive(false);
        
    }
}
