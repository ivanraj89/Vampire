using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnCoffin;
    private Camera cam = null;
    private Vector3 offset = new Vector3(0, 1.8f, 0);
    private RaycastHit hit;
    

    // Start is called before the first frame update
    void Start() //grabbing camera in order to shoot ray from it to the ground collider
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePos();
    }

    private void SpawnAtMousePos()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if(Physics.Raycast(ray, out hit))
            {
                StartCoroutine(DestroySpawnedObject()); // destroys the spawned coffin after 2 seconds
            }
        }
    }

    private IEnumerator DestroySpawnedObject()
    {
        GameObject coffinClone = Instantiate(spawnCoffin, hit.point + offset, Quaternion.identity); //spawns coffin at an offset above the ground

        yield return new WaitForSeconds(2);

        Destroy(coffinClone);
    }
}
