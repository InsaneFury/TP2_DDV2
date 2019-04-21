using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("SlowMo Settings")]
    public float slowmoFactor = 0.05f;
    public float slowmoLength = 2f;

    private static TimeManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static TimeManager Instance()
    {
        return instance;
    }

    void Update()
    {
        Time.timeScale += (1f / slowmoLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmo()
    {
        Time.timeScale = slowmoFactor;
        Debug.Log(Time.timeScale);
    }
}
