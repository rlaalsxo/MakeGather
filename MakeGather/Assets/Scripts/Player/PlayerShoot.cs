using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerController _controller;
    [SerializeField] private Transform projectileSpawnPostion;
    private Vector2 _aimDirection = Vector2.right;
    public GameObject testPrefeb;
    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }
    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }
    private void OnShoot()
    {
        CreateProjectile();
    }
    private void CreateProjectile()
    {
        Instantiate(testPrefeb, projectileSpawnPostion.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
