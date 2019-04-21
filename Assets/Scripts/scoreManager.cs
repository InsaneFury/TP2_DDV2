using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("ScoreUISettings")]
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI shootsUI;
    public GameObject winUI;
    public GameObject loseUI;

    [Header("ScoreSettings")]
    public int score;
    public int scoreValue;
    public int scoreToWin;
    public int shoots;
    public int pinCount;

    Ball player;
    private static ScoreManager instance;

    void Awake()
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

    public static ScoreManager Instance()
    {
        return instance; 
    }

    void Start()
    {
        pinCount = 10;
        score = 0;
        player = GameObject.FindGameObjectWithTag("ball").GetComponent<Ball>();
    }

    void Update()
    {
        scoreUI.text = score.ToString();
        shootsUI.text = shoots.ToString();
        if ((score < scoreToWin && pinCount > 0)&& player.noMoreShoots)
        {
            player.alreadyShooted = true;
            loseUI.SetActive(true);
        }
        if (score == scoreToWin)
        {
            player.alreadyShooted = true;
            winUI.SetActive(true);
        }
    }
}
