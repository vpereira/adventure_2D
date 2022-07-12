using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField]
    private GameObject[] prefabs;

    public GameObject Player { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        
        var selectedOption = PlayerPrefs.GetInt("selectedOption", 0);
        Debug.Log(selectedOption);
        Player = Instantiate(prefabs[selectedOption], getSpawnPosition(), Quaternion.identity);
        Player.name = "Player";
    }

    private Vector3 getSpawnPosition()
    {
        return GameObject.Find("SpawnPosition").transform.position;
    }
}
