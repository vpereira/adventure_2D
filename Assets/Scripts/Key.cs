using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    [SerializeField] private Text keysText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Awake()
    {
        keysText = getKeysText();
    }

    private Text getKeysText()
    {
        return GameObject.FindGameObjectWithTag("KeysText").GetComponent<Text>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject, 0.1f);
            collision.GetComponent<KeyCollector>().IncreaseKeysCount();
            keysText.text = getTotalKeysText();
        }
    }

    private string getTotalKeysText()
    {
        var totalKeys = GameObject.Find("NumberOfKeys").GetComponent<NumberOfKeys>().NumberOfKeysOnTheScene();
        var playerKeys = GameObject.Find("Player").GetComponent<KeyCollector>().Keys();
        return $"KEYS: {playerKeys}/{totalKeys}";
    }
}
