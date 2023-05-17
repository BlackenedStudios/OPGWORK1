using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private void Start()
    {
        rb.AddForce(Vector3.left * Random.Range(-1f, 1f) + Vector3.up * Random.Range(-1f, 1f));
        rb.AddTorque(Vector3.one * Random.Range(180, 360));
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        rb.transform.localScale -= Time.deltaTime * Vector3.one * 0.1f;
    }
}
