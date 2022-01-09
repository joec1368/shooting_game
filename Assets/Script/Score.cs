using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score : " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + score.ToString();
    }
}
