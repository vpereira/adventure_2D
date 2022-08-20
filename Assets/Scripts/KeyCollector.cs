using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{

    // it will be set per level
    // use a KeyManager for that
    const int TOTAL_KEYS = 1;

    private int _keys = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AreAllKeysFound()
    {
        return _keys == TOTAL_KEYS;
    }

    public void IncreaseKeysCount()
    {
        _keys += 1;
    }
}
