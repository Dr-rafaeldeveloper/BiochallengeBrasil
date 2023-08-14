using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageCarroseul : MonoBehaviour
{
    public Sprite[] imageSprites;
    public Image imageDisplay;

    public float fadeSpeed = 1.0f;

    public AnimationCurve fadeCurveIn;
    public AnimationCurve fadeCurveOut;

    private int currentIndex = 0;

    private void OnEnable()
    {
        imageDisplay.sprite = imageSprites[currentIndex];
        StopCoroutine(StartCarousel());
        StopCoroutine(ChangeImage());
        StartCoroutine(StartCarousel());
    }

    private IEnumerator StartCarousel()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeImage());
            currentIndex = (currentIndex + 1) % imageSprites.Length;
        }
    }

    private IEnumerator ChangeImage()
    {
        float startTime = Time.time;
        Color initialColor = imageDisplay.color;

        while (Time.time - startTime < fadeSpeed)
        {
            float t = (Time.time - startTime) / fadeSpeed;
            float curveValue = fadeCurveIn.Evaluate(t); 
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Lerp(1f, 0f, curveValue));
            imageDisplay.color = newColor;
            yield return null;
        }

        imageDisplay.sprite = imageSprites[currentIndex];

        startTime = Time.time;
        while (Time.time - startTime < fadeSpeed)
        {
            float t = (Time.time - startTime) / fadeSpeed;
            float curveValue = fadeCurveOut.Evaluate(t);
            Color newColor = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Lerp(0f, 1f, curveValue));
            imageDisplay.color = newColor;
            yield return null;
        }

        //yield return new WaitForSeconds(2f);
    }
}
