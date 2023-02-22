using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject _spawnBullet;
    private float _bulletSpeed = 10;

    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //StartCoroutine(FindSpawner());
    }

    public void ShootBullet()
    {
        if (_spawnBullet == null)
        {
            _spawnBullet = GameObject.Find("BulletSpawner");
        }
        GameObject bullet = Instantiate(bulletPrefab, _spawnBullet.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _bulletSpeed;
    }

    IEnumerator FindSpawner()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        _spawnBullet = GameObject.Find("BulletSpawner");
    }
}
