using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas_Calls : MonoBehaviour
{
    public static Canvas_Calls instance;
    private void Awake(){
        instance = this;
    }

    public float RedNote_Timer;

    public Image Player_Health;
    public TMP_Text Player_Health_tx;
    public TMP_Text Red_Note;

    public Image Player_Experience;
    public TMP_Text Player_Experience_tx;

    public Image Player_Level;
    public TMP_Text Player_Level_tx;
    
    public void RedNote_Call(string note){
      Red_Note.text = note;
      StartCoroutine(EndRed_Note());
    }

    private IEnumerator EndRed_Note(){
        yield return new WaitForSeconds(RedNote_Timer);
        Red_Note.text = "";
    }
}
