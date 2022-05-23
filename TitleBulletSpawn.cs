using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBulletSpawn : MonoBehaviour
{
    public GameObject refrectBullet;
    Rigidbody rb;
    public GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        RefrectFire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefrectFire()
    {
        Vector3 bulletSpawnPoint = bulletSpawn.transform.position;
        rb = Instantiate(refrectBullet, bulletSpawnPoint, bulletSpawn.transform.rotation * Quaternion.Euler(0, -90, 90)).GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.transform.forward * 15, ForceMode.Impulse);

    }
}
