using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{


    private int _keys = 0;

    // Start is called before the first frame update
        // TODO it could be a setter
    public void AddKey()
    {
        _keys++;
    }

    // TODO transform it in a property
    public int Keys()
    {
        return _keys;
    }
}
