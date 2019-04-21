using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    //Ball
    [Header("BallSettings")]
    public float moveSpeed;
    public float rotationSpeed;
    public float rightLimiter;
    public float leftLimiter;
    public float impulseSpeed;
    public float maxImpulseSpeed;
    public float minImpulseSpeed;
    public float impulseSum;
    public bool  alreadyShooted;
    public float timeToResetBall;

    [HideInInspector]
    public bool noMoreShoots; //This variable is used to verificate if is it your last shoot

    [Header("SlowMoSettings")]
    public bool activeSlowmo = false;

    [Header("BallUISettings")]
    public Slider powerBar;
    public TextMeshProUGUI powerText;

    
    float moveHorizontal;
    Vector3 defaultPos;
    Rigidbody rb;
    CameraFollow cam;

    void Start()
    {
        noMoreShoots = false;
        alreadyShooted = false;
        rb = GetComponent<Rigidbody>();
        minImpulseSpeed = 200f;
        impulseSpeed = minImpulseSpeed;
        defaultPos = transform.position;
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        cam = FindObjectOfType<Camera>().GetComponent<CameraFollow>();
    }

    void Update()
    {
        powerText.text = impulseSpeed.ToString();
        powerBar.value = impulseSpeed / 1000f + 0.2f;
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && (alreadyShooted == false))
        {
            transform.position = new Vector3(transform.position.x, 
                                             transform.position.y,
                                             transform.position.z + moveHorizontal * moveSpeed * Time.deltaTime);
        }

        if (Input.GetButton("Jump") && (alreadyShooted == false))
        {
            impulseSpeed += impulseSum;
            if (impulseSpeed >= maxImpulseSpeed)
            {
                while (impulseSpeed > minImpulseSpeed)
                {
                    impulseSpeed -= impulseSum;
                }
            }
        }
        if (Input.GetKeyUp("space") 
            && (alreadyShooted == false) 
            && ScoreManager.Instance().shoots > 0)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.left * impulseSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            alreadyShooted = true;
            ScoreManager.Instance().shoots--;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("camLimit") && activeSlowmo)
        {
            TimeManager.Instance().DoSlowmo();
        }
        if (col.CompareTag("canaleta"))
        {
            StartCoroutine(ResetBallPos(timeToResetBall));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("canaleta"))
        {
            StartCoroutine(ResetBallPos(timeToResetBall));
        }
    }

    public IEnumerator ResetBallPos(float time)
    {
        yield return new WaitForSeconds(time);
        cam.ResetCamPos();
        transform.position = defaultPos;
        alreadyShooted = false;
        rb.isKinematic = true;
        rb.isKinematic = false;
        if (ScoreManager.Instance().shoots == 0)
        {
            noMoreShoots = true;
        }
        StopCoroutine("ResetBallPos");
    }

    public void activeSlowMoBTN()
    {
        activeSlowmo = !activeSlowmo;
    }
}
