using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]private float force; 
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private float gravity;
    [SerializeField] private float maxHeightTreshold;
    private Rigidbody playerRB;
    private bool playerIsAlive = true;
    private Transform FlappyBird3D;

    private Animator BirdAnimator;

    // Start is called before the first frame update
    void Start()
    {   
        playerRB = GetComponent<Rigidbody>();
        GameManager.Instance.OnPlayerDeath.AddListener(OnPlayerDeath);
        BirdAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        if (!playerIsAlive) return;

        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y <= maxHeightTreshold)
        {
            BirdAnimator.SetBool("Fly",true);
            playerRB.AddForce(Vector3.up * force, forceMode);
            FlappyBird3D.rotation = Quaternion.Lerp(FlappyBird3D.rotation, Quaternion.Euler(0, -110, 0), 0.5f);
            FlappyBird3D.rotation = Quaternion.Lerp(FlappyBird3D.rotation, Quaternion.Euler(90, -110, 0), 0.5f);
        }
        else
        {
            BirdAnimator.SetBool("Fly", false);
        }
    }

    private void OnPlayerDeath()
    {
        playerIsAlive = false;
    }

    
}
