using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject astroidPrefab;

    private float _time;
    private void Update()
    {
        if(Time.time > _time)
        {
            Instantiate(astroidPrefab,transform.position + Vector3.right * Random.Range(-3,3),Quaternion.identity);
            _time = Time.time + 1;
        }
    }
}
