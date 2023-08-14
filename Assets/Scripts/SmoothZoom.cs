using System.Collections;
using UnityEngine;

public class SmoothZoom : MonoBehaviour
{
    [SerializeField] private float animationSpeed = 6f;
    [SerializeField] private float _animationDelay = 0.1f;

    private Vector3 initialScale = Vector3.zero;
    private Vector3 targetScale = Vector3.one;

    private void OnEnable()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.localScale = initialScale;
        StartCoroutine(SmoothZoomCoroutine());
    }

    private IEnumerator SmoothZoomCoroutine()
    {
        yield return new WaitForSeconds(_animationDelay);

        while (Vector3.Distance(transform.localScale, targetScale) > 0.00f)
        {
            float step = animationSpeed * Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, step);
            yield return null;
        }
        transform.localScale = targetScale;
    }
}
