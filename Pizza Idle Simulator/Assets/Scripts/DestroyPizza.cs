using UnityEngine;

public class DestroyPizza : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chao"))
        {
            Destroy(gameObject); // destrói o próprio objeto onde o script está
        }
    }
}
