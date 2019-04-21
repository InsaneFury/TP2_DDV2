using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public float offset;
    public static bool nonStop;

    // Start is called before the first frame update
    void Start()
    {
        nonStop = true;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nonStop)
        {
            cam.transform.position = new Vector3(target.transform.position.x + offset, transform.position.y, transform.position.z);
        }
    }

}
