using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public int dinheiro = 0;
    public float multiplicadorDeDinheiro = 1f;


    public void AdicionarDinheiro(int valor)
    {
        int valorFinal = Mathf.RoundToInt(valor * multiplicadorDeDinheiro);
        dinheiro += valorFinal;
        Debug.Log("Dinheiro atual: " + dinheiro);
    }

    public void RemoverDinheiro(int valor)
    {
        dinheiro -= valor;
        if (dinheiro < 0) dinheiro = 0;
        Debug.Log("Dinheiro atual: " + dinheiro);
    }

    public int GetDinheiroAtual()
    {
        return dinheiro;
    }
}
