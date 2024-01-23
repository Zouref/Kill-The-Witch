using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public float Health;
  private float MaxHealth;
  public float Hti_Power;

  private Animator anim;

  private bool isFighting = false;
  private Transform Player;

    void Start(){
      MaxHealth = Health;
      anim = GetComponent<Animator>();
    }

    public void Damaged(float f){
      if (Health > 0) {
       Health -= f;
       // Now the Enemie is Fighting
       if (!isFighting){ StartCoroutine(FindPlayer_cor()); }
       Enemy_Canvas.instance.ShowHealth(Health,MaxHealth);
       if (Health <= 0) {
        Health = 0;
        DieNow();
       }
      }
    }

    private IEnumerator FindPlayer_cor(){
      Player = GameObject.Find("Player").transform;
      yield return new WaitUntil(() => Player != null);
      isFighting = true;
    }

    public void DieNow(){
      this.gameObject.tag = "Dead";
      anim.SetBool("Dead", true);
    }

    void Update(){
      if (isFighting) transform.LookAt(Player);
    }
}
