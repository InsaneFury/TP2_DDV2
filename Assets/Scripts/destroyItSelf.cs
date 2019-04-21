using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyItSelf : MonoBehaviour
{
    public float timeToDestroy = 5f;

    void Start()
    {
        gameObject.SetActive(false);
    }
}
