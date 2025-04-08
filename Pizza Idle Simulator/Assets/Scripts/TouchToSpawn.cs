using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToSpawn : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public Transform spawnPoint;
    private bool canSpawn = true;

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.CompareTag("Player") && canSpawn)
                        {
                            StartCoroutine(SpawnWithDelay());
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Player") && canSpawn)
                    {
                        StartCoroutine(SpawnWithDelay());
                    }
                }
            }
        }
    }

    IEnumerator SpawnWithDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(0.6f);
        Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
        canSpawn = true;
    }
}
