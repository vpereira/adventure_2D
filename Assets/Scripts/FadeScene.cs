using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeScene : MonoBehaviour
{

    [SerializeField]
    private float switchSceneTime = 0f;


    private float minAlpha = 0f;
    private float maxAlpha = 1f;

    private CanvasGroup cv;

    private float t = 0f;


    private void Awake()
    {
        cv = GetComponent<CanvasGroup>();
        cv.alpha = 0;
    }

    private void Update()
    {
        cv.alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
        t += 0.2f * Time.deltaTime;

        if (t > 1.0)
        {
            t = 0.0f;
            maxAlpha = 0;
            minAlpha = 1;
            Invoke("switchScene", switchSceneTime);
        }
    }


    void switchScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
