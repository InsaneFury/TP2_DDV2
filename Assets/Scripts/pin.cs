using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    [Header("PinSettings")]
    public float time;
    public float minAngleToBeDeleted = -80f;
    public float maxAngleToBeDeleted = 80f;

    float angle;
    bool pinOut;
    Transform originalPos;

    void Start()
    {
        pinOut = false;
        originalPos = transform;
    }

    void Update()
    {
        if (transform.localEulerAngles.z > maxAngleToBeDeleted || transform.localEulerAngles.z < minAngleToBeDeleted ||
            transform.localEulerAngles.x > maxAngleToBeDeleted || transform.localEulerAngles.x < minAngleToBeDeleted)
        {
            if (!pinOut)
            {
                ScoreManager.Instance().score += ScoreManager.Instance().scoreValue;
                pinOut = true;
                StartCoroutine(HideDropedPines(time));
            }
        }
    }

    public void ResetPin()
    {
        transform.position = originalPos.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(true);
    }

    public IEnumerator HideDropedPines(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        StopCoroutine("HideDropedPines");
    }
}
