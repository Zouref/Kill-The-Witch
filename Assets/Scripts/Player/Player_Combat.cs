using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public static Player_Combat instance;
    private void Awake(){
      instance = this;
    }
    
    public float ToEndAnim;
    private float Small_Timer, Mediem_Timer, Big_Timer, Hill_Timer;
    public float MaxSmall, MaxMediem, MaxBig, MaxHill;
    [HideInInspector] public Animator playerAnim;
    private float WaitToMove;
    public float Small_Wait, Mediem_Wait, Big_Wait, Hill_Wait;

    [Header("Damage")]

    public float SmallDamage, MediemDamager, BigDamage;

    private bool CanHit = true;
    [HideInInspector] public bool CanMove = true;
    [HideInInspector] public bool CanFight = false;

    [Header("Fight Mechanics")] public GameObject Mechanics;

    [Header("Effect")] public ParticleSystem Small_ef, Mediem_ef, Big_ef, Hill_ef;

    void Start(){
      playerAnim = this.GetComponent<Animator>();
      StartCoroutine(StartMechanics());
    }

    private IEnumerator StartMechanics(){
      yield return new WaitForSeconds(1f);
      Mechanics.SetActive(true);
    }

    void Update(){

       if (Input.GetKeyDown(KeyCode.Alpha1) && CanHit){
        if (CanFight){
         if (Small_Timer == 0) { Small_Attack(); } else { Canvas_Calls.instance.RedNote_Call("Still Charging!"); }
        } else {
         Canvas_Calls.instance.RedNote_Call("Select Target First!");
       }
       }

       if (Input.GetKeyDown(KeyCode.Alpha2) && CanHit){
        if (CanFight){
         if (Mediem_Timer == 0) {Mediem_Attack();} else { Canvas_Calls.instance.RedNote_Call("Still Charging!"); }
        } else {
         Canvas_Calls.instance.RedNote_Call("Select Target First!");
        }
       }

       if (Input.GetKeyDown(KeyCode.Alpha3) && CanHit){
        if (CanFight){
         if (Big_Timer == 0) {Big_Attack();} else { Canvas_Calls.instance.RedNote_Call("Still Charging!"); }
        } else {
        Canvas_Calls.instance.RedNote_Call("Select Target First!");
       }
       }

       if (Input.GetKeyDown(KeyCode.Alpha4) && CanHit){
         if (Hill_Timer == 0){ Hill();} else { Canvas_Calls.instance.RedNote_Call("Still Charging!"); }
       }

       if (Small_Timer > 0){
         Small_Timer -= 1 * Time.deltaTime;
         Player_Canvas.instance.Ability_Lock[0].fillAmount = Small_Timer / MaxSmall;
         if (Small_Timer < 0){
          Small_Timer = 0;
         }
       }

       if (Mediem_Timer > 0){
         Mediem_Timer -= 1 * Time.deltaTime;
         Player_Canvas.instance.Ability_Lock[1].fillAmount = Mediem_Timer / MaxMediem;
         if (Mediem_Timer < 0){
          Mediem_Timer = 0;
         }
       }

       if (Big_Timer > 0){
         Big_Timer -= 1 * Time.deltaTime;
         Player_Canvas.instance.Ability_Lock[2].fillAmount = Big_Timer / MaxBig;
         if (Big_Timer < 0){
          Big_Timer = 0;
         }
       }

       if (Hill_Timer > 0){
         Hill_Timer -= 1 * Time.deltaTime;
         Player_Canvas.instance.Ability_Lock[3].fillAmount = Hill_Timer / MaxHill;
         if (Hill_Timer < 0){
          Hill_Timer = 0;
         }
       }

       
    }
    
    public float Small_To_Sound;
    public void Small_Attack(){
      playerAnim.SetBool("S_A", true);
      Small_Timer = MaxSmall;
      CanHit = false;
      WaitToMove = Small_Wait;
      StartCoroutine(SmallPlaySound_cor());
      StartCoroutine(DoneHitAnim_cor(Small_Wait));
      StartCoroutine(SendDamage(Small_Wait ,SmallDamage));
    }

    private IEnumerator SmallPlaySound_cor(){
      yield return new WaitForSeconds(Small_To_Sound);
      Player_Sounds.instance.PlaySound("Small_Hit");
    }


    public void Mediem_Attack(){
      playerAnim.SetBool("M_A", true);
      Mediem_Timer = MaxMediem;
      CanHit = false;
      WaitToMove = Mediem_Wait;
      StartCoroutine(DoneHitAnim_cor(Mediem_Wait));
      StartCoroutine(SendDamage(Mediem_Wait, MediemDamager));
    }

    public void Big_Attack(){
      playerAnim.SetBool("B_A", true);
      Big_Timer = MaxBig;
      CanHit = false;
      WaitToMove = Big_Wait;
      StartCoroutine(DoneHitAnim_cor(Big_Wait));
      StartCoroutine(SendDamage(Big_Wait ,BigDamage));
    }

    public void Hill(){
      playerAnim.SetBool("H", true);
      Hill_Timer = MaxHill;
      CanHit = false;
      WaitToMove = Hill_Wait;
      Player_Sounds.instance.PlaySound("Hill");
      Hill_ef.Play();
      StartCoroutine(DoneHitAnim_cor(Hill_Wait));
    }

    private IEnumerator SendDamage(float TimeToWai, float Damage){
      yield return new WaitForSeconds(TimeToWai);
      Player_Mechanics.instance.DoDamage(Damage);
    }

    private IEnumerator DoneHitAnim_cor(float timing){
        StartCoroutine(FinishHiting_cor());
        yield return new WaitForSeconds(timing);
        playerAnim.SetBool("S_A", false);
        playerAnim.SetBool("M_A", false);
        playerAnim.SetBool("B_A", false);
        playerAnim.SetBool("H", false);
    }

    private IEnumerator FinishHiting_cor(){
      CanHit = false;
      CanMove = false;
      yield return new  WaitForSeconds(WaitToMove);
      CanMove = true;
      CanHit = true;
    }

  
}
