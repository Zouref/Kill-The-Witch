using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mechanics : MonoBehaviour
{
  public static Player_Mechanics instance;
  private void Awake(){
    instance = this;
  }

  public float RayCats_Long;
  [HideInInspector] public GameObject Current_Enemy;

  void Update(){

    Ray ray = new Ray(transform.position, transform.forward);

    // Check if the ray hits anything.
    if (Physics.Raycast(ray, out RaycastHit hit, RayCats_Long))
    {
      if (hit.transform.gameObject.tag == "Enemy") {
       Current_Enemy = hit.transform.gameObject;
       Player_Canvas.instance.Target_Note.SetActive(true);
       Player_Combat.instance.CanFight = true;
       Player_Combat.instance.playerAnim.SetBool("Combat", true);
      }

    } else {
      Player_Canvas.instance.Target_Note.SetActive(false);
      Player_Combat.instance.CanFight = false;
      Player_Combat.instance.playerAnim.SetBool("Combat", false);
    }

  }

  public void DoDamage(float f) {
    Current_Enemy.GetComponent<Enemy>().Damaged(f);
  }

}
