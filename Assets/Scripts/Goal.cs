using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Canvas youWon;


    KeyManager _km;

    private void Awake()
    {
        
        _km = GameObject.Find("KeyManager").GetComponent<KeyManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _km.AreAllKeysFound())
        {
            // TODO
            // We have to control if the door is open or close
            // We shouldnt win, but move to the next level
            youWon.GetComponent<Canvas>().enabled = true;
            PlayerManager.Instance.Player.SetActive(false);
        }
    }
}
