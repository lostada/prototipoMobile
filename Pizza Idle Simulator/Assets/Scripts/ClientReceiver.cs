using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientReceiver : MonoBehaviour
{
    public MoneySystem dinheiroSistema;
    public int valorDaPizza = 10;
    private bool ocupado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza") && !ocupado)
        {
            StartCoroutine(VenderPizza(other));
        }
    }

    IEnumerator VenderPizza(Collider pizza)
    {
        ocupado = true;

        // Para o Rigidbody e ativa trigger
        Rigidbody rb = pizza.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Collider col = pizza.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }

        // Coloca a pizza parada em frente ao cliente
        pizza.transform.position = transform.position + new Vector3(0, 0.5f, 0);

        dinheiroSistema.AdicionarDinheiro(valorDaPizza);

        yield return new WaitForSeconds(4f);

        Destroy(pizza.gameObject);
        ocupado = false;
    }
}
