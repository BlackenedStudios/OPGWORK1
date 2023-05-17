using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject astroidPrefab;
    [SerializeField] private GameObject buffPrefab;

    private float _time;
    private float _buffTime;

    private void Start()
    {
        _buffTime = Time.time + 5;
    }
    private void Update()
    {
        if (Time.time > _time)
        {
            Instantiate(astroidPrefab, transform.position + Vector3.right * Random.Range(-3f, 3f), Quaternion.identity);
            _time = Time.time + 1;
        }
        if (Time.time > _buffTime)
        {
            Transform buff = Instantiate(buffPrefab).transform;
            buff.position = new Vector3(Random.Range(-4f, 4f), 3, 0);
            _buffTime = Time.time + 15;
        }
    }
}