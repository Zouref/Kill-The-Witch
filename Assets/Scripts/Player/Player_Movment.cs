using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment : MonoBehaviour
{
  
    public float Default_Speed, Speed;
    private float ShiftSpeed;
    public float RunSpeed;
    public float rotationSpeed;
    private Vector3 PlayerMov_vct;
    private float UsedSpeed;
    
    public Animator playerAnim;

    // Jump
    private Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    private bool jumped;
    Rigidbody rb;
    public float JumpHold;
    public float RunJumpHold;

    // Start is called before the first frame update
    void Start()
    {
      // Jump Set Settings
      rb = GetComponent<Rigidbody>();
      jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay(){
      isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
          if (vertical > 0) {
            ShiftSpeed = RunSpeed;
          }
        } else {
          ShiftSpeed = 0f;
        }
        
        if (Player_Combat.instance.CanMove){
         PlayerMov_vct.z = vertical;
         UsedSpeed = Speed + ShiftSpeed;
         transform.Translate(PlayerMov_vct * UsedSpeed * Time.deltaTime);
         
         transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

         if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {

          if (ShiftSpeed == 0){
           JumpNow();
          } else if (ShiftSpeed == RunSpeed) {
           RunJump();
          }

         }

        }

        // Anim Actions

        if (vertical > 0.1f && UsedSpeed == Speed){
          playerAnim.SetBool("Walk", true);
          if (!jumped) {Player_Sounds.instance.walking = true;} else {Player_Sounds.instance.walking = false;}
        } else {
          playerAnim.SetBool("Walk", false);
        }

        if (vertical < -0.05f){
          playerAnim.SetBool("Back", true);
          if (!jumped) {Player_Sounds.instance.walking = true;} else {Player_Sounds.instance.walking = false;}
        } else if (vertical > -0.1f && vertical < 0.1f){
          playerAnim.SetBool("Back", false);
        }

        if (vertical > 0.1f && UsedSpeed > Speed){
          playerAnim.SetBool("Run", true);
          if (!jumped) {Player_Sounds.instance.Runing = true;} else {Player_Sounds.instance.Runing = false;}
        } else {
          playerAnim.SetBool("Run", false);
          Player_Sounds.instance.Runing = false;
        }

        if (vertical == 0){
         playerAnim.SetBool("Idle", true);
         Player_Sounds.instance.walking = false;
        } else {
         playerAnim.SetBool("Idle", false);
        }

    }

    public void RunJump(){
      playerAnim.SetBool("Jump", true);
      jumped = true;
      StartCoroutine(RunJumping_cor());
    }

    private IEnumerator RunJumping_cor(){
      yield return new WaitForSeconds(.15f);
      rb.AddForce(jump * jumpForce, ForceMode.Impulse);
      isGrounded = false;
      Player_Sounds.instance.PlaySound("Jump");
      yield return new WaitForSeconds(RunJumpHold);
      Player_Sounds.instance.PlaySound("Land");
      jumped = false;
      playerAnim.SetBool("Jump", false);
    }

    public void JumpNow(){
      playerAnim.SetBool("Jump", true);
      jumped = true;
      StartCoroutine(Jumping_cor());
    }

    private IEnumerator Jumping_cor(){
      yield return new WaitForSeconds(.15f);
      rb.AddForce(jump * jumpForce, ForceMode.Impulse);
      isGrounded = false;
      Player_Sounds.instance.PlaySound("Jump");
      yield return new WaitForSeconds(JumpHold);
      Player_Sounds.instance.PlaySound("Land");
      jumped = false;
      playerAnim.SetBool("Jump", false);
      
    }
}
