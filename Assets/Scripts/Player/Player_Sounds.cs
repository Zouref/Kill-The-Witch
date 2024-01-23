using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sounds : MonoBehaviour
{
    public static Player_Sounds instance;
    private void Awake(){
        instance = this;
    }

    // Start Script
    private AudioSource walkSource;
    public AudioSource otherSource;
    
    public AudioClip[] WalkStep;
    public float walkSpeed, RunSpeed;
    private float BetweenWalk = 1f;
    public float walkVolume = .6f;
    private int walkingStep;

    public AudioClip Jump,Land;
    public AudioClip Small_hit, Mediem_hit, Big_hit, Hill;

    [HideInInspector] public bool walking, Runing;

    void Start(){
     walkSource = GetComponent<AudioSource>();
     StartCoroutine(walking_cor());
    }

    private IEnumerator walking_cor(){
     yield return new WaitForSeconds(BetweenWalk);
     if (walkingStep < WalkStep.Length){
       walkSource.clip = WalkStep[walkingStep];
       walkingStep++;
     } else {
       walkingStep = 0;
       walkSource.clip = WalkStep[walkingStep];
       walkingStep++;
     }
     walkSource.Play();
     StartCoroutine(walking_cor());
    }

    void Update(){
        if (walking) {
          BetweenWalk = walkSpeed;
          walkSource.volume = walkVolume;
        } else {
          walkSource.volume = 0.00f;
        }

        if (Runing){
          BetweenWalk = RunSpeed;
          walkSource.volume = walkVolume;
        }
    }

    public void PlaySound(string WhatAction){
      if (WhatAction == "Jump") {
        otherSource.clip = Jump;
      } else if (WhatAction == "Land"){
        otherSource.clip = Land;
      } else if (WhatAction == "Small_Hit"){
        otherSource.clip = Small_hit;
      } else if (WhatAction == "Mediem_Hit"){
        otherSource.clip = Mediem_hit;
      } else if (WhatAction == "Big_Hit"){
        otherSource.clip = Big_hit;
      } else if (WhatAction == "Hill"){
        otherSource.clip = Hill;
      }

      otherSource.Play();

    }

}
