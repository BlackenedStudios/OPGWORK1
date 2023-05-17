using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public List<Mesh> meshes;
    public List<Material> materials;

    public GameObject explosionObject;

    private MeshFilter _filter;
    private MeshRenderer _renderer;

    private int direction = 1;

    private void Awake()
    {
        Construct();
    }
    private void Construct()
    {
        _filter = GetComponentInChildren<MeshFilter>();
        _renderer = GetComponentInChildren<MeshRenderer>();

        _filter.mesh = meshes[Random.Range(0, meshes.Count)];
        _renderer.material = materials[Random.Range(0, materials.Count)];
        
        if(Random.Range(0,10) > 5)
        {
            direction = -1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ExplosionEffect();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    public void OnHitPlayer()
    {
        ExplosionEffect();

        Destroy(gameObject);
    }
    private void ExplosionEffect()
    {
        for(int i = 0; i < 5;i++)
        {
            Instantiate(explosionObject, transform.position, Quaternion.identity).GetComponent<Renderer>().material = _renderer.material;
        }
    }
    private void FixedUpdate()
    {
        _filter.transform.Rotate(Vector3.one * 45 * Time.deltaTime);
        transform.Translate((Vector3.down * 0.4f + Vector3.right * direction) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 4.5) direction = -direction;
    }
}
