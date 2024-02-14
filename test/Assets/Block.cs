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
                bz = temp.bz;
               bz.AddBlock(gameObject);
               inTower = true;
                bz.CheckHighestBlock();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "buildZone" && !inTower)
        {
            bz = other.gameObject.GetComponent<buildZone>();
            inTower = true;
            bz.AddBlock(gameObject);
        }
    }
}
