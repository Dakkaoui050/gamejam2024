using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool inTower;
    public bool firstBlock;
    public buildZone bz;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Block temp = collision.gameObject.GetComponent<Block>();
            if (temp.inTower && !inTower)
            {
               bz = GetComponent<buildZone>();
               bz.AddBlock(gameObject);
               inTower = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "buildZone")
        {
            bz = other.gameObject.GetComponent<buildZone>();
            inTower = true;
        }
    }
}
