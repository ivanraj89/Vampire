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
    void Start()
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
                StartCoroutine(DestroySpawnedObject());
            }
        }
    }

    private IEnumerator DestroySpawnedObject()
    {
        GameObject coffinClone = Instantiate(spawnCoffin, hit.point + offset, Quaternion.identity);

        yield return new WaitForSeconds(2);

        Destroy(coffinClone);
    }
}
