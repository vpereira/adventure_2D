using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Canvas youWon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        youWon.GetComponent<Canvas>().enabled = true;
        var player = GameObject.Find("Player");
        player.SetActive(false);
    }
}
