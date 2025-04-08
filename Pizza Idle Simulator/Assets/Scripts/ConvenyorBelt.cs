using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 beltDirection = Vector3.forward;
    public float beltSpeed = 2f;
    public GameObject pizzaPrefab;
    public Transform spawnPoint;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 move = beltDirection.normalized * beltSpeed * Time.deltaTime;
                rb.MovePosition(rb.position + move);
            }
        }
    }

    public void SpawnPizza()
    {
        if (pizzaPrefab != null && spawnPoint != null)
        {
            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("PizzaPrefab ou SpawnPoint não estão configurados!");
        }
    }
}
