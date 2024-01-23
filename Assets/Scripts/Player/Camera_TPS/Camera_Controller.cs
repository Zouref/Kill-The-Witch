using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public static Camera_Controller instance;
    private void Awake(){
      instance = this;
    }

    private Animator anim;

    void Start(){
      anim = GetComponent<Animator>();
    }

    public void Quest_View(){
      anim.Play("Quest_View");
    }

    public void Quest_Back(){
      anim.Play("Quest_Back");
    }

    public void Fighting(){
      anim.Play("Fight_Mode");
    }

    public void Back_Fight(){
      anim.Play("Back_Fight");
    }

}
