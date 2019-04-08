using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
       
            camera_follow.nonStop = false;
        
    }
}
