using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float score = 10f;

    public void Hit()
    {
        Score.AddScore(score);
    }
}
