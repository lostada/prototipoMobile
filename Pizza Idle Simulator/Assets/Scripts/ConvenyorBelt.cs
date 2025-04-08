using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenyorBelt : MonoBehaviour
{
    public Vector3 beltDirection = Vector3.forward;  // Direção do movimento da esteira (pode ser Vector3.forward, Vector3.right, etc.)
    public float beltSpeed = 2f;                      // Velocidade da esteira
    public GameObject pizzaPrefab;                    // Prefab da pizza que será instanciada (você pode arrastar isso no inspetor)
    public Transform spawnPoint;                      // Ponto de onde as pizzas irão aparecer

    private void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto que colidiu com a esteira é uma pizza (assumindo que as pizzas têm uma tag "Pizza")
        if (other.CompareTag("Pizza"))
        {
            // Move a pizza na direção da esteira com a velocidade definida
            other.transform.Translate(beltDirection * beltSpeed * Time.deltaTime, Space.World);
        }
    }

    // Método para instanciar a pizza na esteira
    public void SpawnPizza()
    {
        if (pizzaPrefab != null && spawnPoint != null)
        {
            // Instancia a pizza no ponto de spawn com a rotação padrão (sem rotação)
            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("PizzaPrefab ou SpawnPoint não estão configurados!");
        }
    }
}
