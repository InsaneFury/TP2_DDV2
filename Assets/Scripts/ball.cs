using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    float moveHorizontal;
    public float moveSpeed;
    public float rotationSpeed;
    public float rightLimiter;
    public float leftLimiter;
    public float impulseSpeed;
    bool alreadyShooted;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        alreadyShooted = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && (alreadyShooted == false)) {
            rb.AddForce(new Vector3(0f, 0f, moveHorizontal * moveSpeed * Time.deltaTime),ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown("space") && (alreadyShooted == false)) {
            rb.AddForce(Vector3.left * impulseSpeed * Time.deltaTime, ForceMode.VelocityChange);
            alreadyShooted = true;
        }
    }
}
