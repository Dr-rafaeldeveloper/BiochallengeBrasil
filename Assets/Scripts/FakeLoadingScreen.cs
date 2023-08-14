using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class FakeLoadingScreen : MonoBehaviour
{
    public float loadingTime = 1.0f;
    public float delayPerIncrement = 0.05f;
    public Image imageFillAmount;
    public TextMeshProUGUI TMPro;

    private float currentProgress = 0.0f;

    private void Start()
    {
        StartCoroutine(FakeLoadingCoroutine());
    }

    private IEnumerator FakeLoadingCoroutine()
    {
        while (currentProgress < 1.0f)
        {
            yield return new WaitForSeconds(delayPerIncrement);
            currentProgress += 1.0f / (loadingTime / delayPerIncrement);
            currentProgress = Mathf.Clamp01(currentProgress);
            imageFillAmount.fillAmount = currentProgress;
            string text = (currentProgress * 100).ToString("F0") + "%";
            TMPro.text = text;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene((int)Scenes.Gameplay);
    }
}
