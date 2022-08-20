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
        if(collision.CompareTag("Player"))
        {
            var player = GameObject.Find("Player");
            // TODO
            // We have to control if the door is open or close
            if(player.GetComponent<KeyCollector>().AreAllKeysFound())
            {
                youWon.GetComponent<Canvas>().enabled = true;
                player.SetActive(false);
            }
        }
    }
}
