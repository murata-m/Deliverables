using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurveBullet : MonoBehaviour
{
    //
    //CurveBullet
    //

    public GameObject audio_ob;

    Rigidbody rb;
    int curveHorizonCondition = 150;
    float rotationSpeed =-3.4f;
    //↑PlayerContorollerのcurveHorizonCondition,curveVerticalConditionに依存。カーブの最小半径を決める。これをpercenntにより同時に操作
    Vector3 bulletRotation;
    float bulletRotationZ; 
    bool isForce=true;
   // public GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // rb.AddForce(bulletSpawn.transform.forward * PlayerController.bulletSpeed, ForceMode.Impulse);
        //rb=gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(-transform.forward * PlayerController.bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
        bulletRotation = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(bulletRotation);
        bulletRotationZ = bulletRotation.z;
        
        //Debug.Log("初期角度" + bulletRotationZ);
        if (bulletRotationZ - 180 >= 0)
        {
            bulletRotationZ -= 180;
        }
        else
        {
            bulletRotationZ = 360 + (bulletRotationZ - 180);
        }
       
        //Debug.Log( "目標角度" + bulletRotationZ);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void FixedUpdate()
    {
        Invoke("BulletCurveCondition", PlayerController.curvePoint);
        bulletRotation = transform.localRotation.eulerAngles;
        if (PlayerController.percentage != 0)
        {
            if ((int)bulletRotation.z >= bulletRotationZ && (int)bulletRotation.z <= bulletRotationZ + 1)
            {
                bulletRotation = transform.localRotation.eulerAngles;
                bulletRotation.z = bulletRotationZ;
                transform.localRotation = Quaternion.Euler(bulletRotation);
                rb.angularVelocity = Vector3.zero;
                isForce = false;
            }
        }
        
    }

    

    public void BulletCurveCondition()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (isForce)
        {
            rb.angularVelocity = transform.forward * rotationSpeed * PlayerController.percentage * 0.01f;
            rb.AddForce(-transform.right * curveHorizonCondition*PlayerController.percentage * 0.01f, ForceMode.Force);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Map")
        {
            Destroy(gameObject);
        }
        if (other.tag == "target_white")
        {
            Instantiate(audio_ob, transform.position, transform.rotation);
            ScoreManager.score += 10;
            Destroy(gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            ScoreManager.targetNum -= 1;
            
        }
        if (other.tag == "target_red")
        {
            ScoreManager.score += 20;
            Destroy(gameObject);
        }
        if (other.tag == "target_yellow")
        {
            ScoreManager.score += 20;
            Destroy(gameObject);
        }
        if (other.tag == "backcollider")
        {
            Destroy(gameObject);
        }
        
    }

    
}
