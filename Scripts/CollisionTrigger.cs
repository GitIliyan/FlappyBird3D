using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.OnPlayerDeath.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.AdjustScore(1);
        }
    }


}
