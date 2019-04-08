using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{

    public float slowmoFactor = 0.05f;
    public float slowmoLength = 2f;

    void Update()
    {
        Time.timeScale += (1f / slowmoLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmo() {
        Time.timeScale = slowmoFactor;
        //Time.fixedDeltaTime = Time.timeScale * .02f; otra de manera de arreglar los cortes de frame en los objetos
        Debug.Log(Time.timeScale);
    }
}
