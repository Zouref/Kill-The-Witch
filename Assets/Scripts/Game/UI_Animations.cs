using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animations : MonoBehaviour
{
    public static UI_Animations instance;
    private void Awake(){
        instance = this;
    }

    public Animator Action_Bar, Quest_Panel;

    public void Show_Quest_Panel(){
        Action_Bar.Play("Hide");
        Quest_Panel.Play("Show");
    }

    public void Hide_Quest_Panel(){
        Action_Bar.Play("Show");
        Quest_Panel.Play("Hide");
    }
}
