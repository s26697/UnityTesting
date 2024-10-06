using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [SerializeField] private GameObject _ProjectilePrefab;
    [SerializeField] private float _Cooldown = 2;
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(_ProjectilePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(_Cooldown);
        }
       
    }

    
    
}
