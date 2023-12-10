using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalButton : MonoBehaviour
{
   [SerializeField] private GameObject modal;

   public void OnClickModalButton()
   {
       modal.SetActive(true);
   }
}
