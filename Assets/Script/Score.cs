using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public static float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponent<Text>();
        text.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score.ToString();
    }

    public static void AddScore(float amount)
    {
        score += amount;
    }
}
