using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetLookAt : MonoBehaviour
{
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        var pt = getPlayer().transform;
        vcam.LookAt = pt;
        vcam.Follow = pt;
    }

    private GameObject getPlayer()
    {
        return PlayerManager.Instance.Player;
    }
}
