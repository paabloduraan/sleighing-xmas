using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

      public GameObject target;
      public float camSpeed = 10.0f;

      void FixedUpdate () {
            Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
      }
}