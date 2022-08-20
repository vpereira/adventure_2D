using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfKeys : MonoBehaviour
{

    [SerializeField]
    int numberOfKeys = 1;

    public int NumberOfKeysOnTheScene()
    {
        return numberOfKeys;
    }
}
