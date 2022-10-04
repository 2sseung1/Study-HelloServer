using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : ButtonEvent
{
    [SerializeField]
    private Image targetImage;
    [SerializeField]
    private float fadeInTime;
    [SerializeField]
    private float fadeOutTime;

    protected override void OnClickEvent()
    {
        StartCoroutine(UIManager.Instance.FadeInOut(targetImage, fadeInTime, fadeOutTime));
    }
}