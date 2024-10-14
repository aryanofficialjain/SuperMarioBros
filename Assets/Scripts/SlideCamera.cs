using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCamera : MonoBehaviour
{
    // Start is called before the first frame update
   private Transform player;

   private void Awake(){
    player = GameObject.FindWithTag("Player").transform;


    
   }

   private void LateUpdate(){
    Vector3 cameraPosition = transform.position;
    cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
    transform.position = cameraPosition;

   }
}
