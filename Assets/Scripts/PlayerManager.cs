using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Vector3 spawnPosition = new Vector3(-68, 9, 0);
        Player = Instantiate(prefabs[0], spawnPosition, Quaternion.identity);
        Player.name = "Player";
        
    }

    private Vector3 getSpawnPosition()
}
