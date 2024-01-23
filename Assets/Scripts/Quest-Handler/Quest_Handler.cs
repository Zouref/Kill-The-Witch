using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Handler : MonoBehaviour
{
   private void OnTriggerEnter(Collider col){
     if (col.gameObject.tag == "Player"){
       Camera_Controller.instance.Quest_View();
       UI_Animations.instance.Show_Quest_Panel();
     }
   }

   private void OnTriggerExit(Collider col){
    Camera_Controller.instance.Quest_Back();
    UI_Animations.instance.Hide_Quest_Panel();
   }
}
