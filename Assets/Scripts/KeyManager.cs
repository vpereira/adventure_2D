using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    AudioSource collectKeySound;

    [SerializeField]
    int numberOfKeysLevel;

    [SerializeField] private Text keysText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateKeysUI();
    }

    public string GetKeysString()
    {
        return $"KEYS: {playerKeys()}/{numberOfKeysLevel}";
    }

    public bool AreAllKeysFound()
    {
        return playerKeys() == numberOfKeysLevel;
    }

    int playerKeys()
    {
        return PlayerManager.Instance.Player.GetComponent<KeyCollector>().Keys();
    }

    public void AddKey()
    {
        PlayerManager.Instance.Player.GetComponent<KeyCollector>().AddKey();
    }
    
    public void UpdateKeysUI()
    {
        keysText.text = GetKeysString();
    }

    public void PlaySound()
    {
        collectKeySound.Play();
    }
}
