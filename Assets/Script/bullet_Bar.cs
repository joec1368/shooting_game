using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet_Bar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public float bullet_now;
    public Text text;
    int temp = 0;

    private void Start()
    {
        FillSlider();
        bullet_now = slider.maxValue;
        text.text = bullet_now.ToString();
        
    }
    public void Update()
    {
        FillSlider();
    }

    public void FillSlider()
    {
        slider.value = bullet_now;
        //slider.value = 10f;
        text.text = bullet_now.ToString();
        if (Input.GetMouseButton(0))
        {
            bullet_now--;
            if(bullet_now == 0)
            {
                fill.enabled = false;
                temp = 1;
            }
            else if(temp == 1)
            {
                temp = 0;
                fill.enabled = true;
                bullet_now = slider.maxValue;
            }
            else
            {
                temp = 0;
                fill.enabled = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.R)){
            bullet_now = slider.maxValue;
        }
    }
}
