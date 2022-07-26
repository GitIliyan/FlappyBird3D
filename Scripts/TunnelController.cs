using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        GameManager.Instance.OnPlayerDeath.AddListener(OnPlayerDeath);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*(speed*Time.deltaTime);
    }

    private void OnPlayerDeath() 
    { 
        speed = 0f;
    }
}
