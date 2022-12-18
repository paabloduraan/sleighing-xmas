using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

      // public GameHandler gameHandler;
       public Transform pSpawn;       // current player spawn point
       public GameHandler gameHandlerObj;

       public GameObject Santa;
       public GameObject Grinch;

       void Start() {
            //  gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

       void OnCollisionEnter2D(Collision2D Col)
      {
          if (Col.gameObject.tag == "icicle")
          {
              Debug.Log("I am going back to the last spawn point");
              Vector3 pSpn2 = new Vector3(pSpawn.position.x, pSpawn.position.y, transform.position.z);
              gameObject.transform.position = pSpn2;

              Debug.Log("here");
              if (gameObject.transform.GetChild(0).CompareTag("grinch")) {
                  if (GameHandler.playerScore < 3) {
                     GameHandler.playerScore = 0;
                  }
                  else {
                      gameHandlerObj.AddScore(-3);
                  }
              } else {
                  if (GameHandler.playerScore2 < 3) {
                      GameHandler.playerScore2 = 0;
                  }
                  else {
                      gameHandlerObj.AddScore2(-3);
                  }
              }
          }

      }

       public void OnTriggerEnter2D(Collider2D other) {
              if (other.gameObject.tag == "CheckPoint"){
                            pSpawn = other.gameObject.transform;
                            GameObject thisCheckpoint = other.gameObject;
                            StopCoroutine(changeColor(thisCheckpoint));
                            StartCoroutine(changeColor(thisCheckpoint));
              }
       }

       IEnumerator changeColor(GameObject thisCheckpoint){
              Renderer checkRend = thisCheckpoint.GetComponentInChildren<Renderer>();
              checkRend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              yield return new WaitForSeconds(0.5f);
              checkRend.material.color = Color.white;
       }
}
