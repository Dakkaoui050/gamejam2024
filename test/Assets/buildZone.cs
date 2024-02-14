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

    public GameObject CheckHighestBlock()
    {
        GameObject temp = Tower[0];
        foreach (GameObject block in Tower)
        {
            if (temp.transform.position.y < block.transform.position.y)
            {
                temp = block;
            }
        }
        towerHeight = temp.transform.position.y;
        return temp;
    }
}
