using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{


    // TODO
    // code from itecomllector, key and numberOfKeys could be extract to one keymanager
    private int _numOfKeysScene;
    private int _keys = 0;

    // Start is called before the first frame update
    void Start()
    {
        var nOfK = GameObject.Find("NumberOfKeys").GetComponent<NumberOfKeys>();
        _numOfKeysScene = nOfK.NumberOfKeysOnTheScene();
    }
    public bool AreAllKeysFound()
    {
        return _keys == _numOfKeysScene;
    }


    // TODO it could be a setter
    public void IncreaseKeysCount()
    {
        _keys += 1;
    }

    // TODO transform it in a property
    public int Keys()
    {
        return _keys;
    }
}
