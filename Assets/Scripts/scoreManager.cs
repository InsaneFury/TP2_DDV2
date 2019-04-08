using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;
    public int scoreValue;

    // Start is called before the first frame update
    void Start() {
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        scoreUI.text = score.ToString();
    }
}
