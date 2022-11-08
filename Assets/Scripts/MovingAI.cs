using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float obstacleRange = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() // moves the transform forward constantly which checking if the ray directed at it is within a certain limit. If it is then turn. 
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.5f,out hit))
        {
            
            if (hit.distance < obstacleRange )
            {
                float angle = Random.Range(-45  , 45);
                transform.Rotate(0, angle , 0);
            }
        }
    }
}
