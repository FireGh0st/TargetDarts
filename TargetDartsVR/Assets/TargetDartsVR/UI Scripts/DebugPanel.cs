using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    public void DestroyDarts() 
    {
        GameObject[] darts = GameObject.FindGameObjectsWithTag("Dart");
        foreach (GameObject dart in darts) 
        {
            Destroy(dart);
        }
    }
}
