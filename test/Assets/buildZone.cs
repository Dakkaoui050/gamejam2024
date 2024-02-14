using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildZone : MonoBehaviour
{
    public float towerHeight;
    public List<GameObject> Tower;

    public void AddBlock(GameObject block)
    {
        Tower.Add(block);
    }
}
