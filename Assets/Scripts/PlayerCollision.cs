using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Destroy(this.gameObject); //if it hits the blood pool then destroy this gameobject
            SceneManager.LoadScene(3);
        }
        if (other.CompareTag("Goal")) //the blue area which is the final area. once reached load next scene
        {
            SceneManager.LoadScene(4);
        }
        else if (other.CompareTag("Coffin")) //to avoid getting stuck on coffin object
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
