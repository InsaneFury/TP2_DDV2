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
    Transform originalPos;
    public float time;

    private void Start() {
        gManager = GameObject.Find("GameManager");
        sManager = gManager.GetComponent<scoreManager>();
        pinOut = false;
        originalPos = transform;
    }
    // Update is called once per frame
    void Update()
    {
        angle = Quaternion.Angle(transform.rotation, floor.rotation);

        if ((angle > 80 || angle < -80) &&(!pinOut)) {
            sManager.score += sManager.scoreValue;
            pinOut = true;
            StartCoroutine(hideDropedPines(time));
        }
    }

   public void resetPin() {
        transform.position = originalPos.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(true);
    }
    
   
    public IEnumerator hideDropedPines(float time) {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        StopCoroutine("hideDropedPines");
    }
}
