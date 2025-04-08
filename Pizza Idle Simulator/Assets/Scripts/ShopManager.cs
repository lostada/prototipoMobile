using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public MoneySystem dinheiroSistema;

    public int precoAssento = 100;
    public int precoChef = 200;
    public int precoMultiplicador = 300;

    public int maxAssentos = 15;
    public int assentosAtuais = 5;

    public int maxChefs = 3;
    public int chefsAtuais = 1;

    public float multiplicador = 1f;

    public TextMeshProUGUI assentosText;
    public TextMeshProUGUI chefsText;
    public TextMeshProUGUI multiplicadorText;

    public List<GameObject> assentosExtras;
    public List<GameObject> chefsExtras;

    void Start()
    {
        AtualizarUI();
    }

    public void ComprarAssento()
    {
        if (dinheiroSistema.GetDinheiroAtual() >= precoAssento && assentosAtuais < maxAssentos)
        {
            dinheiroSistema.RemoverDinheiro(precoAssento);

            int index = assentosAtuais - 5;
            if (index >= 0 && index < assentosExtras.Count)
                assentosExtras[index].SetActive(true);

            assentosAtuais++;
            AtualizarUI();
        }
    }

    public void ComprarChef()
    {
        if (dinheiroSistema.GetDinheiroAtual() >= precoChef && chefsAtuais < maxChefs)
        {
            dinheiroSistema.RemoverDinheiro(precoChef);

            int index = chefsAtuais - 1;
            if (index >= 0 && index < chefsExtras.Count)
                chefsExtras[index].SetActive(true);

            chefsAtuais++;
            AtualizarUI();
        }
    }

    public void ComprarMultiplicador()
    {
        if (dinheiroSistema.GetDinheiroAtual() >= precoMultiplicador)
        {
            dinheiroSistema.RemoverDinheiro(precoMultiplicador);
            multiplicador += 0.5f;
            dinheiroSistema.multiplicadorDeDinheiro = multiplicador;
            AtualizarUI();
        }
    }

    void AtualizarUI()
    {
        assentosText.text = "Assentos: " + assentosAtuais;
        chefsText.text = "Chefs: " + chefsAtuais;
        multiplicadorText.text = "Multiplicador: x" + multiplicador.ToString("0.0");
    }
}
