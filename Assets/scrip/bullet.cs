using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;

public class bullet : MonoBehaviour
{
    public int total_bullet = 100;
    public int per_pack = 10;
    public int now_bullet = 10;
    public Text text;
    public int red_word = 3;
    float start;
    public float timeoffset = 0.5f;
      
    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
        text.text = now_bullet + "/" + total_bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start >= timeoffset)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                now_bullet--;
                if (now_bullet < 0)
                {
                    if (total_bullet - per_pack < 0)
                    {
                        now_bullet = total_bullet;
                        total_bullet = 0;
                    }
                    else
                    {
                        now_bullet = per_pack;
                        total_bullet -= per_pack;
                    }
                }
            }
            if (Input.GetKey(KeyCode.R))
            {
                total_bullet += now_bullet;
                if (total_bullet - per_pack < 0)
                {
                    now_bullet = total_bullet;
                    total_bullet = 0;
                }
                else
                {
                    now_bullet = per_pack;
                    total_bullet -= per_pack;
                }
            }
            start = Time.time;
        }
        if(now_bullet <=  red_word)
        {
            text.color = Color.red;
            text.text = now_bullet + "/" + total_bullet;
        }
        else
        {
            text.color = Color.black;
            text.text = now_bullet + "/" + total_bullet;
        }
            
    }
   
}
