using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("CamSettings")]
    public Camera cam;
    public GameObject target;
    public float offset;
    public float camLimitInX = 5.8f;
    public Vector3 defaultCamPos;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (transform.position.x > camLimitInX)
        {
            cam.transform.position = new Vector3(target.transform.position.x + offset, transform.position.y, transform.position.z);
        }
    }

    public void ResetCamPos()
    {
        cam.transform.position = defaultCamPos;
    }
}
