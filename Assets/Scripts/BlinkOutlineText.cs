using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlinkOutlineText : MonoBehaviour
{
    [SerializeField]
    private float defaultTargetTime = 0.5f;
    private float targetTime = 0f;


    private void Awake()
    {
        targetTime = defaultTargetTime;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0f)
        {

            var outlines = GetComponents<Outline>();
            foreach (Outline outline in outlines)
            {
                outline.enabled = !outline.enabled;
                targetTime = defaultTargetTime;
            }
        }
    }


}
