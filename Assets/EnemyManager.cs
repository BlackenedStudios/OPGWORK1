using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int direction = 1;

    private float countDown = 0;
    private void FixedUpdate()
    {
        if(countDown > 0) transform.Translate(Vector3.down * Time.deltaTime);
        else transform.Translate(Vector3.right * direction * Time.deltaTime);

        if (countDown > 0) countDown -= Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > 4.5 && countDown <= 0) 
        {
            transform.position = new Vector3(transform.position.x > 0 ? 4.4f : -4.4f, transform.position.y, transform.position.z);
            countDown = 1f;
            direction = -direction;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
