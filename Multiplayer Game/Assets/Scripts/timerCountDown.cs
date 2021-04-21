using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerCountDown : MonoBehaviour
{
    [SerializeField] float startTime = 5f;
    [SerializeField] Slider slider;
    [SerializeField] Text timerText;

    float timer = 0f;
    void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
         timer = startTime;

        do
        {
            timer -= Time.deltaTime;
            slider.value = timer / startTime;
            FormatText();
            yield return null;
        }
        while (timer>0);
    }
    private void FormatText()
    {
        int minutes = (int)(timer / 60) % 60 ;
        int seconds = (int)(timer % 60);

        timerText.text = "";

        if(minutes>0)
        {
            timerText.text += minutes + ":";
        }
        if (seconds > 0)
        {
            timerText.text += seconds + "";
        }
    }
    
}
