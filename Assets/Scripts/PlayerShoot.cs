using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        bullet.transform.position = transform.position;

        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 400f);
    }
}
