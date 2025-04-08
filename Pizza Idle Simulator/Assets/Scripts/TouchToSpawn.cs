using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToSpawn : MonoBehaviour
{
    public GameObject pizzaPrefab;  // O prefab da pizza que ser� instanciado
    public Transform spawnPoint;    // O ponto de spawn da pizza

    void Update()
    {
        // Verifica se estamos em um dispositivo mobile ou no PC
        if (Application.isMobilePlatform)
        {
            // Verifica se h� pelo menos um toque na tela
            if (Input.touchCount > 0)
            {
                // Obt�m o primeiro toque
                Touch touch = Input.GetTouch(0);

                // Verifica se o toque foi iniciado
                if (touch.phase == TouchPhase.Began)
                {
                    // Cria um raio a partir da posi��o do toque na tela para o mundo
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    // Realiza o Raycast, verificando o que o raio atingiu
                    if (Physics.Raycast(ray, out hit))
                    {
                        // Verifica se o objeto atingido pelo raycast tem a tag "Player"
                        if (hit.transform.CompareTag("Player"))
                        {
                            // Instancia a pizza na posi��o de spawn, sem rota��o
                            Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
        else
        {
            // Se n�o for um dispositivo mobile, verifica o clique do mouse
            if (Input.GetMouseButtonDown(0))
            {
                // Cria um raio a partir da posi��o do mouse na tela para o mundo
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Realiza o Raycast, verificando o que o raio atingiu
                if (Physics.Raycast(ray, out hit))
                {
                    // Verifica se o objeto atingido pelo raycast tem a tag "Player"
                    if (hit.transform.CompareTag("Player"))
                    {
                        // Instancia a pizza na posi��o de spawn, sem rota��o
                        Instantiate(pizzaPrefab, spawnPoint.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
