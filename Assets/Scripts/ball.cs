using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ball : MonoBehaviour
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

    [Header("SlowMoSettings")]
    public bool activeSlowmo = false;

    [Header("BallUISettings")]
    public Slider powerBar;
    public TextMeshProUGUI powerText;

    float moveHorizontal;
    Vector3 defaultPos;
    Rigidbody rb;

    void Start()
    {
        alreadyShooted = false;
        rb = GetComponent<Rigidbody>();
        minImpulseSpeed = 200f;
        impulseSpeed = minImpulseSpeed;
        defaultPos = transform.position;
    }

    void Update()
    {
        powerText.text = impulseSpeed.ToString();
        powerBar.value = impulseSpeed / 1000f + 0.2f;
        moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && (alreadyShooted == false))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveHorizontal * Time.deltaTime);
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
        if (Input.GetKeyUp("space") && (alreadyShooted == false) && ScoreManager.Instance().shoots > 0)
        {
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
            StartCoroutine(resetBallPos(timeToResetBall));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("canaleta"))
        {
            StartCoroutine(resetBallPos(timeToResetBall));
        }
    }

    public IEnumerator resetBallPos(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = defaultPos;
        alreadyShooted = false;
        camera_follow.nonStop = true;
        rb.isKinematic = true;
        rb.isKinematic = false;
        StopCoroutine("resetBallPos");
    }

    public void activeSlowMoBTN()
    {
        activeSlowmo = !activeSlowmo;
    }
}
