using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    protected override void Initialize()
    {

    }

    #region Coroutine

    public IEnumerator FadeInOut(Image image, float fadeInTime, float fadeOutTime)
    {
        StartCoroutine(FadeIn(image, fadeInTime));

        yield return new WaitForSeconds(fadeInTime);

        StartCoroutine(FadeOut(image, fadeOutTime));
    }

    public IEnumerator FadeIn(Image image, float fadeInTime)
    {
        Color newColor = image.color;
        float increaseValue = 1 / fadeInTime;
        while (image.color.a < 1)
        {
            yield return null;

            newColor.a += increaseValue * Time.deltaTime;
            image.color = newColor;
        }
    }

    public IEnumerator FadeOut(Image image, float fadeOutTime)
    {
        Color newColor = image.color;
        float decreaseValue = 1 / fadeOutTime;
        while (0 < image.color.a)
        {
            yield return null;

            newColor.a -= decreaseValue * Time.deltaTime;
            image.color = newColor;
        }
    }

    #endregion
}