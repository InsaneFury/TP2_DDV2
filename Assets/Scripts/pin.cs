using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    float angle;
    public Transform floor;
    bool pinOut;

    private void Start() {
        pinOut = false;
    }
    // Update is called once per frame
    void Update()
    {
        angle = Quaternion.Angle(transform.rotation, floor.rotation);

        if ((angle > 80 || angle < -80) &&(!pinOut)) {
            scoreManager.score++;
            pinOut = true;
        }
    }
}
