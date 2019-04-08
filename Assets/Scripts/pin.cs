using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    float angle;
    public Transform floor;
    bool pinOut;
    GameObject gManager;
    scoreManager sManager;

    private void Start() {
        gManager = GameObject.Find("GameManager");
        sManager = gManager.GetComponent<scoreManager>();
        pinOut = false;
    }
    // Update is called once per frame
    void Update()
    {
        angle = Quaternion.Angle(transform.rotation, floor.rotation);

        if ((angle > 80 || angle < -80) &&(!pinOut)) {
            sManager.score += sManager.scoreValue; ;
            pinOut = true;
        }
    }
}
