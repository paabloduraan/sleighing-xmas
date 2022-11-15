using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MultiPlayerMoveAround : MonoBehaviour{

      //public Animator anim;
      //public AudioSource WalkSFX;
      public int jumpcount = 0;
      public int maxJumpCount = 1;
      public Rigidbody2D rb2D;
      private bool FaceRight = true; // determine which way player is facing.
      public static float runSpeed = 10f;
      public float startSpeed = 10f;
      public bool isAlive = true;
      public bool isPlayer1 =false;
      public Vector3 hvMove;
      public float jumpforce = 10f;

      void Start(){
           //anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
      }

      void Update(){
         //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
         //NOTE: Vertical axis: [w] / up arrow, [s] / down arrow
        if (isPlayer1 == true){
            hvMove = new Vector3(Input.GetAxis("p1Horiz"), Input.GetAxis("p1Vert"), 0.0f);
        }
        else {
            hvMove = new Vector3(Input.GetAxis("p2Horiz"), Input.GetAxis("p2Vert"), 0.0f);
        }

        if (isAlive == true){
                  transform.position = transform.position + hvMove * runSpeed * Time.deltaTime;

                  if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0)){
                  //     anim.SetBool ("Walk", true);
                  //     if (!WalkSFX.isPlaying){
                  //           WalkSFX.Play();
                  //     }
                  } else {
                  //     anim.SetBool ("Walk", false);
                  //     WalkSFX.Stop();
                 }

                  // Turning. Reverse if input is moving the Player right and Player faces left.
                 if ((hvMove.x <0 && !FaceRight) || (hvMove.x >0 && FaceRight)){
                        playerTurn();
                  }
            }
            if (Input.GetKeyDown(KeyCode.Space) && (jumpcount > 0))
                {
                    rb2D.AddForce(Vector3.up * jumpforce,ForceMode2D.Impulse);
                    jumpcount -= 1;
                }
      }

      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }

      void OnCollisionEnter2D(Collision2D Col)
     {
         if (Col.gameObject.tag == "ground")
         {
            jumpcount = maxJumpCount;
         }

        if (Col.gameObject.tag == "gifts") {
            Destroy(Col.gameObject);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
