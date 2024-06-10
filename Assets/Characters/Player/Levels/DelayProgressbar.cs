using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.Reactor;
using UnityEngine;
using UnityEngine.UI;

public class DelayProgressbar : MonoBehaviour
{
    [SerializeField]
    private Progressor progressor;
    private float progressorValueLastFrame;
    [SerializeField]
    private Image progressbarImage;
    [SerializeField]
    private float delayTime, speed;
    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        // If progressor value changed since last frame
        if (progressorValueLastFrame != progressor.currentValue)
        {
            timer = delayTime;
            progressorValueLastFrame = progressor.currentValue;
        }

        if (timer <= 0)
        {
            if (progressbarImage.fillAmount < progressor.currentValue)
                progressbarImage.fillAmount += Time.deltaTime * speed;
        }

        // Reset the delayed fill when the progressor value is either lower or has been reset
        if (progressor.currentValue == 0)
            progressbarImage.fillAmount = 0;
    }
}
