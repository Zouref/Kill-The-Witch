using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public static Player_Stats instance;
    private void Awake(){
        instance = this;
    }

    public float Health, MaxHealth;
    public int Level, MaxLevel;
    public float Experience;
    public float[] MaxExperience;

    public float Attack_Power;
    public float Diffence_Power;

    public float Mana;

    // Start is called before the first frame update
    void Start()
    {
        GetStats();
    }

    public void GetStats(){

        // Get Health and MaxHealth Prefs
        Canvas_Calls.instance.Player_Health.fillAmount = Health / MaxHealth;
        Canvas_Calls.instance.Player_Health_tx.text = Health.ToString() + "/" + MaxHealth.ToString() + " HP";

        // Get Experience and Level
        Canvas_Calls.instance.Player_Level.fillAmount = (float)Level / (float)MaxLevel;
        Canvas_Calls.instance.Player_Level_tx.text = Level.ToString();

        Canvas_Calls.instance.Player_Experience.fillAmount = Experience / MaxExperience[Level];
        Canvas_Calls.instance.Player_Experience_tx.text = Experience.ToString() + " / " + MaxExperience[Level].ToString() + " XP";
    }

    public void Minus_Health(float f){
     Health += f;
     GetStats();
    }

    public void Plus_Health(float f){
     Health -= f;
     GetStats();
    }

    public void Plus_Experience(float f){
      float NeededExperience = MaxExperience[Level] - Experience;
      if (f < NeededExperience){
        Experience += f;
      } else if (f >= NeededExperience) {
        float TheRest = f - NeededExperience;
        Level_UP();
        Experience = TheRest;
      }
      GetStats();
    }

    public void Level_UP(){
      Level++;
    }

}
