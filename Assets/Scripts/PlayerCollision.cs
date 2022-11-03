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
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }
        if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene(4);
        }
        else if (other.CompareTag("Coffin"))
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
