using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{


    KeyManager _km;

    private void Awake()
    {
        _km = GameObject.Find("KeyManager").GetComponent<KeyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject, 0.1f);
            _km.AddKey();
            _km.UpdateKeysUI();
            _km.PlaySound();
        }
    }
}
