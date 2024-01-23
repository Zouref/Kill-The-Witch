using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Canvas : MonoBehaviour
{
    public static Player_Canvas instance;
    private void Awake(){
        instance = this;
    }

    public Image[] Ability_Lock;
    public GameObject Target_Note;
    
}
