using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform visual;
    [SerializeField] private Transform weaponPosition;

    [SerializeField] private List<Transform> doubleWeaponPositions;

    [SerializeField] private float sensivity = 0.5f;
    [SerializeField] private float playableAreaLimit = 0.5f;

    private Rigidbody _rigidbody;
    private Collider _collider;

    private float _input;

    private bool _upgrade = false;

    public static PlayerController instance;

    private void Awake()
    {
        Construct();
    }
    private void Construct()
    {
        if(instance == null)
        {
            instance = this;
        }
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        Application.targetFrameRate = 60;
        Screen.SetResolution(1000, 1000, false);
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Shoot(Vector3 position)
    {
        Rigidbody rb = Instantiate(bulletPrefab,position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 100);
    }

    private void GetInput()
    {
        _input = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_upgrade)
            {
                doubleWeaponPositions.ForEach(x => 
                {
                    Shoot(x.position);
                });
            }
            else
            {
                Shoot(weaponPosition.position);
            }
        }
    }
    private void Movement()
    {
        _rigidbody.MovePosition(new Vector3(Mathf.Clamp(_rigidbody.position.x + _input * 0.5f , -playableAreaLimit , playableAreaLimit), -2.5f, 0));
        visual.rotation = Quaternion.Lerp(visual.rotation, Quaternion.Euler(-90, -45 * _input, 0), Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astroid"))
        {
            other.GetComponent<Astroid>().OnHitPlayer();
        }
    }
}
