using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public MoneySystem dinheiroSistema;
    public TextMeshProUGUI textoDinheiro;

    void Update()
    {
        textoDinheiro.text = "Dinheiro: " + dinheiroSistema.GetDinheiroAtual().ToString();
    }
}
