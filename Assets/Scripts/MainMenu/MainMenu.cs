using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    private void Awake(){
      instance = this;
    }

    public void Play(){
      SceneManager.LoadScene("Loading");
    }
}
