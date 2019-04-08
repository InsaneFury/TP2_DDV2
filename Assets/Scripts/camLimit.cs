using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camLimit : MonoBehaviour
{
    public bool stopCamera;

    private void OnTriggerEnter(Collider other) {
        if (stopCamera) {
            camera_follow.nonStop = false;
        }     
    }
}
