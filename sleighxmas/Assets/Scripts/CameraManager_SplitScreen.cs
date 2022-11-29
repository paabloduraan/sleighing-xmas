using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraManager_SplitScreen : MonoBehaviour{

      // public GameObject divider;
      public GameObject cameraMain;
      public GameObject cameraPlayer1;
      public GameObject cameraPlayer2;
      public GameObject player1;
      public GameObject player2;
      public float cameraDistance = 5f;

      void Update(){
            // divider = GameObject.Find("Divider");
            FindPlayerCenter(); //the GameHandler acts as the target for the MainCamera

            float playerDistance = Vector3.Distance(player1.transform.position, player2.transform.position); //get distance
            //if distance is within threshold, use fullscreen MainCamera
            if (playerDistance < cameraDistance){
                  cameraPlayer1.GetComponent<Camera>().enabled = false;
                  cameraPlayer2.GetComponent<Camera>().enabled = false;
                  // if (divider != null) {
                  //     turnOnDivider(divider);
                  // }
                  
                  cameraMain.GetComponent<Camera>().enabled = true;
            }
            //else, use splitscreen
            else {
                  cameraPlayer1.GetComponent<Camera>().enabled = true;
                  cameraPlayer2.GetComponent<Camera>().enabled = true;
                  // turnOffDivider(divider);
                  cameraMain.GetComponent<Camera>().enabled = false;
            }
      }
      // 
      // void turnOnDivider(GameObject object) {
      //     object.SetActive(true);
      // }
      // 
      // void turnOffDivider(GameObject object) {
      //     object.SetActive(false);
      // }

      // set this object's position to the center of the two players
      void FindPlayerCenter(){
            Vector3 pos;
            pos.x = player1.transform.position.x + (player2.transform.position.x - player1.transform.position.x) / 2;
            pos.y = player1.transform.position.y + (player2.transform.position.y - player1.transform.position.y) / 2;
            pos.z = player1.transform.position.z + (player2.transform.position.z - player1.transform.position.z) / 2;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
      }
}
