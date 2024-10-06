
using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{

     private Rigidbody2D _rb;

    [SerializeField] private float _speed = 2;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rb.velocity = (transform.right * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        Destroy(other.gameObject);
        Debug.Log("Player has been destroyed !");
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
