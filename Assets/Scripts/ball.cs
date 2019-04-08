using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{

    //Ball
    float moveHorizontal;
    public float moveSpeed;
    public float rotationSpeed;
    public float rightLimiter;
    public float leftLimiter;
    public float impulseSpeed;
    public float maxImpulseSpeed;
    public float minImpulseSpeed;
    public float impulseSum;
    bool alreadyShooted;
    Rigidbody rb;

    //UI
    public TextMeshProUGUI powerText;

    //Time FX
    public timeManager tm;

    // Start is called before the first frame update
    void Start()
    {
        alreadyShooted = false;
        rb = GetComponent<Rigidbody>();
        minImpulseSpeed = 200f;
        impulseSpeed = minImpulseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = impulseSpeed.ToString();
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && (alreadyShooted == false)) {
            rb.AddForce(new Vector3(0f, 0f, moveHorizontal * moveSpeed * Time.fixedDeltaTime),ForceMode.VelocityChange);
        }
        if (Input.GetButton("Jump") && (alreadyShooted == false)) {

            impulseSpeed+=impulseSum;
            if(impulseSpeed >= maxImpulseSpeed) {
                while(impulseSpeed > minImpulseSpeed) {
                    impulseSpeed -= impulseSum;
                }  
            }     
        }
        if (Input.GetKeyUp("space")) {
            rb.AddForce(Vector3.left * impulseSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            alreadyShooted = true;
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("camLimit")) {
            tm.DoSlowmo();
        }
        
    }
}
