using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy_Canvas : MonoBehaviour
{
    public static Enemy_Canvas instance;
    private void Awake(){
        instance = this;
    }
    
    public GameObject Health_Show;
    public Image Health_bar;
    public TMP_Text Health_tx;

    private float Show_Time = 0;
    public float ShowTimer;


    public void ShowHealth(float Health, float MaxHealth){
       Health_bar.fillAmount = Health / MaxHealth;
       Health_tx.text = Health.ToString() + " / " + MaxHealth.ToString() + " HP";
       Show_Time = ShowTimer;
    }

    void Update(){
      if (Show_Time > 0f){
        Health_Show.SetActive(true);
        Show_Time -= 1 * Time.deltaTime;
      } else {
        Health_Show.SetActive(false);
      }
    }
}
