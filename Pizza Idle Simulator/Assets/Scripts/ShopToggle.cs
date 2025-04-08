using UnityEngine;

public class ShopToggle : MonoBehaviour
{
    public GameObject menuLoja; // A Image que cont�m os bot�es

    private bool lojaAberta = false;

    public void AlternarLoja()
    {
        lojaAberta = !lojaAberta;
        menuLoja.SetActive(lojaAberta);
    }
}
