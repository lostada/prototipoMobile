using UnityEngine;

public class DestroyPizza : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chao"))
        {
            Destroy(gameObject); // destr�i o pr�prio objeto onde o script est�
        }
    }
}
