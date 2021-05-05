using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class UnityChanHideMesh : MonoBehaviour
{
    public GameObject[] gos;
    public SteamVR_Action_Boolean Trigger;

    // Update is called once per frame
    void Update()
    {
        if ((Trigger != null) && Trigger.GetState(SteamVR_Input_Sources.Any))
        {
            foreach (var go in gos)
            {
                go.SetActive(false);
            }
        }
    }
}
