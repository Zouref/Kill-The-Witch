using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_sc : MonoBehaviour
{
  
  public float Time_To_Wait;
  
  void Start(){
    StartCoroutine(ToGame());
  }

  private IEnumerator ToGame(){
    yield return new WaitForSeconds(Time_To_Wait);
    SceneManager.LoadScene("GamePlay");
  }
}
