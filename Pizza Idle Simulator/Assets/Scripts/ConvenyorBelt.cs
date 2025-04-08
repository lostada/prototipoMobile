using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvenyorBelt : MonoBehaviour
{
    public Vector3 beltDirection = Vector3.forward;  // Dire��o do movimento da esteira (pode ser Vector3.forward, Vector3.right, etc.)
    public float beltSpeed = 2f;                      // Velocidade da esteira
    public GameObject pizzaPrefab;                    // Prefab da pizza que ser� instanciada (voc� pode arrastar isso no inspetor)
    public Transform spawnPoint;                      // Ponto de onde as pizzas ir�o aparecer

    private void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto que colidiu com a esteira � uma pizza (assumindo que as pizzas t�m uma tag "Pizza")
        if (other.CompareTag("Pizza"))
        {
            // Move a pizza na dire��o da esteira com a velocidade definida
            other.transform.Translate(beltDirection * beltSpeed * Time.deltaTime, Space.World);
        }
    }

    // M�todo para instanciar a pizza na esteira
    public void SpawnPizza()
    {
        if (pizzaPrefab != null && spawnPoint != null)
        {
            // Instancia a pizza no ponto de spawn com a rota��o padr�o (sem rota��o)
            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("PizzaPrefab ou SpawnPoint n�o est�o configurados!");
        }
    }
}
