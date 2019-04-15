using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ball : MonoBehaviour
{

    //Ball
    [Header("Variables")]
    float moveHorizontal;
    public float moveSpeed;
    public float rotationSpeed;
    public float rightLimiter;
    public float leftLimiter;
    public float impulseSpeed;
    public float maxImpulseSpeed;
    public float minImpulseSpeed;
    public float impulseSum;
    public bool alreadyShooted;
    public bool activeSlowmo = false;
    public float resetTime;
    Vector3 defaultPos;
    Rigidbody rb;
    public Slider powerBar;

    [HideInInspector]
    public scoreManager ScoreManager;

    //UI
    [Header("UI")]
    public TextMeshProUGUI powerText;

    //Time FX
    [Header("FX")]
    public timeManager tm;

    // Start is called before the first frame update
    void Start(){
        ScoreManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<scoreManager>();
        alreadyShooted = false;
        rb = GetComponent<Rigidbody>();
        impulseSpeed = minImpulseSpeed;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update(){   
        powerText.text = impulseSpeed.ToString();
        powerBar.value = impulseSpeed / 1000f + 0.2f;
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && (alreadyShooted == false)) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveHorizontal * Time.deltaTime);
        }

        if (Input.GetButton("Jump") && (alreadyShooted == false)) {
            impulseSpeed+=impulseSum;
            if(impulseSpeed >= maxImpulseSpeed) {
                impulseSpeed = minImpulseSpeed;  
            }     
        }
        if (Input.GetKeyUp("space") && (alreadyShooted == false) 
            && ScoreManager.shoots > 0) {
            rb.AddForce(Vector3.left * impulseSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            alreadyShooted = true;
            ScoreManager.shoots--;
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("camLimit") && activeSlowmo) {
            tm.DoSlowmo();
        }
        if (col.CompareTag("canaleta")) {
            StartCoroutine(resetBallPos(resetTime));
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("canaleta")) {
            //StartCoroutine(resetBallPos(resetTime));
        }
    }

    public IEnumerator resetBallPos(float time) {
        yield return new WaitForSeconds(time);
        transform.position = defaultPos;
        alreadyShooted = false;
        camera_follow.nonStop = true;
        rb.isKinematic = true;
        rb.isKinematic = false;
        StopCoroutine("resetBallPos");
    }

    public void activeSlowMoBTN() {
        activeSlowmo = !activeSlowmo;
    }
}
