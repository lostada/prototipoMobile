using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToSpawn : MonoBehaviour
{
    public GameObject pizzaPrefab;  // O prefab da pizza que será instanciado
    public Transform spawnPoint;    // O ponto de spawn da pizza

    void Update()
    {
        // Verifica se estamos em um dispositivo mobile ou no PC
        if (Application.isMobilePlatform)
        {
            // Verifica se há pelo menos um toque na tela
            if (Input.touchCount > 0)
            {
                // Obtém o primeiro toque
                Touch touch = Input.GetTouch(0);

                // Verifica se o toque foi iniciado
                if (touch.phase == TouchPhase.Began)
                {
                    // Cria um raio a partir da posição do toque na tela para o mundo
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    // Realiza o Raycast, verificando o que o raio atingiu
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Verifica se o objeto atingido pelo raycast tem a tag "Player"
                        if (hit.transform.CompareTag("Player"))
                        {
                            // Instancia a pizza na posição de spawn, sem rotação
                            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
        else
        {
            // Se não for um dispositivo mobile, verifica o clique do mouse
            if (Input.GetMouseButtonDown(0))
            {
                // Cria um raio a partir da posição do mouse na tela para o mundo
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Realiza o Raycast, verificando o que o raio atingiu
                if (Physics.Raycast(ray, out hit))
                {
                    // Verifica se o objeto atingido pelo raycast tem a tag "Player"
                    if (hit.transform.CompareTag("Player"))
                    {
                        // Instancia a pizza na posição de spawn, sem rotação
                        Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
