using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    public static Quest_Manager instance;
    private void Awake(){
        instance = this;
    }
}
