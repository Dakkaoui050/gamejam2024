using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AIToBlock : MonoBehaviour
{
    public Transform pointA;
    
    [SerializeField] private float moveSpeed = 5f;
   
    private Transform target;

    public GameObject block;


    void Start()
    {
        SetTarget(pointA); // Start by moving towards point B
        pointA = GameObject.FindWithTag("buildZone").GetComponent<Transform>();
       

        
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);

        // Check if the AI has reached the current target
        if (Vector3.Distance(transform.position, pointA.position) < 0.01f)
        {
                SetTarget(pointA);
            
        }
    }

    private void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (block)
        {
            Destroy(gameObject);
        }
    }

}

