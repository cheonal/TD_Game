using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve curve;
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string Scene)
    {
        StartCoroutine(FadeOut(Scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        
    }
    IEnumerator FadeOut(string Scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(Scene);
    }
}
