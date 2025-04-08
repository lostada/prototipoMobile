using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToSpawn : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
                }
            }
        }
    }
}
