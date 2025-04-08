using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    public GameObject menuLoja; // A Image que contém os botões

    private bool lojaAberta = false;

    public void AlternarLoja()
    {
        lojaAberta = !lojaAberta;
        menuLoja.SetActive(lojaAberta);
    }
}
