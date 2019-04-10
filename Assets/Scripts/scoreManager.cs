using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI shootsUI;
    public GameObject winUI;
    public GameObject loseUI;
    public int scoreValue;
    public int scoreToWin;
    public int shoots;

    // Start is called before the first frame update
    void Start() {
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        scoreUI.text = score.ToString();
        shootsUI.text = shoots.ToString();
        if (shoots == 0 && score < scoreToWin) {
            GameObject.FindGameObjectWithTag("ball").GetComponent<ball>().alreadyShooted = true;
            loseUI.SetActive(true);
        }
        if (score == scoreToWin) {
            GameObject.FindGameObjectWithTag("ball").GetComponent<ball>().alreadyShooted = true;
            winUI.SetActive(true);
        }
        if(score < scoreToWin && shoots > 0) {

        }
        
    }
}
