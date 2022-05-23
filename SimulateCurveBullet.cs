using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimurateCurveBullet : MonoBehaviour
{
    //
    //CurveBullet
    //


    Rigidbody rb;
    float rotationSpeed = -3.4f;
    //��PlayerContoroller��curveHorizonCondition,curveVerticalCondition�Ɉˑ��B�J�[�u�̍ŏ����a�����߂�B�����percennt�ɂ�蓯���ɑ���
    Vector3 bulletRotation;
    float bulletRotationZ;
    bool isForce = true;
    int curveHorizonCondition = 150;


    // Start is called before the first frame update
    void Start()
    {
        
        bulletRotation = transform.localRotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(bulletRotation);
        bulletRotationZ = bulletRotation.z;

        //Debug.Log("�����p�x" + bulletRotationZ);
        if (bulletRotationZ - 180 >= 0)
        {
            bulletRotationZ -= 180;
        }
        else
        {
            bulletRotationZ = 360 + (bulletRotationZ - 180);
        }

        //Debug.Log( "�ڕW�p�x" + bulletRotationZ);
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate()
    {
        Invoke("BulletCurveCondition", PlayerController.curvePoint);
        bulletRotation = transform.localRotation.eulerAngles;
        //Debug.Log("z" + (int)bulletRotation.z);
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
            rb.AddForce(-transform.right * curveHorizonCondition * PlayerController.percentage * 0.01f, ForceMode.Force);
        }
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
