using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] private ObjectPool tunnelPool;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tunnel") || other.CompareTag("Score"))
        {
            tunnelPool.ReturnToPool(other.gameObject);
        }
    }
}
