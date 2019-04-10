using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyItSelf : MonoBehaviour
{
    public float timeToDestroy = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
}
