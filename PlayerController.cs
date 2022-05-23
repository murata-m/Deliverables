using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject tankGun;
    public GameObject text;
    public FloatingJoystick inputFire; //�E���JoyStick
    public FixedJoystick inputRotate; //��ʏ�JoyStick
    //public Button curveMode, refrectMode;
    float frontmoveSpeed = 5.0f, backmoveSpeed = 3f; //�ړ����鑬�x
    float rotateSpeed = 1.0f;  //��]���鑬�x
    float bendingAngle = 225f;
    int curvePointball,pointLastball;
    Quaternion cameraRot;
    public GameObject curveBullet;
    public GameObject refrectBullet;
    public GameObject bulletSpawn;
    public GameObject simCurveBullet;
    Rigidbody rb;
    int bulletSpeed = 45 ;
    int curveHorizonCondition = 150;
    public static float percentage=100;
    public static float timeAfter, timebefore;
    public static float curvePoint=1f;

    public AudioSource playerSE;
    public AudioClip launcherSE;
    public AudioSource PlayerSE;
    public AudioClip runningSE;



    [SerializeField]
    private GameObject ballSimPrefab; // ���ł�OK�B�\���ʒu��\������I�u�W�F�N�g

    private int SIMULATE_COUNT; // ������܂ŃV���~���[�g���邩

    private Vector3 _startPosition; // ���ˊJ�n�ʒu
    private List<GameObject> simuratePointList; // �V���~���[�g����Q�[���I�u�W�F�N�g���X�g
    float xvar, yvar, zvar;
    float simulateRotateSpeed = 3.4f;

    int isrunningSE;



    void Start()
    {
        text.SetActive(false);
        curvePointball = 0;
        Init();
        cameraRot = mainCamera.transform.localRotation;
        CurveModeButton.isCurveMode = true;
        RefrectModeButton.isRefrectMode = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (GoMove.go > 0)
        {
            this.transform.position += this.transform.forward * GoMove.go * frontmoveSpeed * Time.deltaTime;
        }
        else if (BackMove.back > 0)
        {
            this.transform.position += -this.transform.forward * BackMove.back * backmoveSpeed * Time.deltaTime;
        }
        transform.Rotate(new Vector3(0, rotateSpeed * inputRotate.Horizontal, 0));
        if (inputRotate.Horizontal != 0)
        {
            isrunningSE +=1;
        }
        else if (inputRotate.Horizontal == 0)
        {
            isrunningSE = 0;
        }
        if (isrunningSE==1)
        {
            RunningSE();
        }
        else if (isrunningSE == 0)
        {
            StopRunningSE();
        }
        cameraRot *= Quaternion.Euler(-inputRotate.Vertical, 0, 0);
        cameraRot = ClampRotation(cameraRot, -60, 20);
        mainCamera.transform.localRotation = cameraRot;
        tankGun.transform.localRotation = cameraRot;
        //PC�p
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += transform.forward * Input.GetAxisRaw("Vertical") * frontmoveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position += transform.forward * Input.GetAxisRaw("Vertical") * backmoveSpeed * Time.deltaTime;
        }



        //�C��

        
        if (CurveModeButton.isCurveMode)
        {
            //rig.isKinematic = false;
            text.SetActive(false);
            if (FloatingJoystick.isOn&&percentage!=0)
            {
                if (simuratePointList != null && simuratePointList.Count > 0)
                {
                    for (int i = 0; i < SIMULATE_COUNT; i++)
                    {
                        if (i == 0)
                        {
                            //Debug.DrawLine(bulletSpawn.transform.position, simuratePointList[i].transform.position);
                        }
                        else
                        if (i < SIMULATE_COUNT)
                        {
                            //Debug.DrawLine(simuratePointList[i - 1].transform.position, simuratePointList[i].transform.position);
                        }
                    }
                }
                GetBendingAngle(inputFire.Horizontal, inputFire.Vertical);
                Vector2 v = new Vector2(inputFire.Horizontal, inputFire.Vertical);
                float vectorMagnitude = v.magnitude;
                percentage = vectorMagnitude * 100;
                curvePoint = 0.2f + (timeAfter - timebefore);
                if (curvePoint > 2f)
                {
                    curvePoint = 2f;
                }

                var vec1 = bulletSpawn.transform.forward*bulletSpeed;
                var vec2 = simCurveBullet.transform.right * curveHorizonCondition ;
                UpdatePointBall();
                Simulate(simCurveBullet, vec1, vec2);
                //Debug.Log(FloatingJoystick.isOff);
                //Debug.Log(percentage);

            }
            if (FloatingJoystick.isOff)
            {
                //rig.isKinematic = true;
                curvePoint = 0.2f+(timeAfter - timebefore);
                if (curvePoint>2f)
                {
                    curvePoint = 2f;
                }
                CurveFire();
                Init();
                
                
            }

        }
        else if (RefrectModeButton.isRefrectMode)
        {
            text.SetActive(true);
            if (FloatingJoystick.isOff && percentage != 0)
            {
                RefrectFire();
            }

        }

    



    }

    private void Init()
    {
        pointLastball = curvePointball + 7;
        SIMULATE_COUNT = pointLastball;
        if (simuratePointList != null && simuratePointList.Count > 0)
        {
            foreach (var go in simuratePointList)
            {
                Destroy(go.gameObject);
            }
        }

        // �ʒu��\������I�u�W�F�N�g��\�ߍ���Ă���
        if (ballSimPrefab != null)
        {
            simuratePointList = new List<GameObject>();
            for (int i = 0; i < SIMULATE_COUNT; i++)
            {
                var go = Instantiate(ballSimPrefab);
                go.transform.SetParent(bulletSpawn.transform);
                go.transform.position = Vector3.zero;
                simuratePointList.Add(go);
            }
        }
    }
    private void UpdatePointBall()
    {
        pointLastball = curvePointball + 7;
        int beforeSimCount = SIMULATE_COUNT;
        SIMULATE_COUNT = pointLastball;
        for (int i = 0; i < SIMULATE_COUNT - beforeSimCount; i++)
        {
            var go = Instantiate(ballSimPrefab);
            go.transform.SetParent(bulletSpawn.transform);
            go.transform.position = Vector3.zero;
            simuratePointList.Add(go);
        }
    }
    public void Simulate(GameObject target, Vector3 vec1,Vector3 vec2)
    {
        
        if (simuratePointList != null && simuratePointList.Count > 0)
        {

            
            // ���ˈʒu��ۑ�����
            _startPosition = bulletSpawn.transform.localPosition;
            var r = target.GetComponent<Rigidbody>();
            if (r != null)
            {
                Vector3 forcestraight = vec1;
                Vector3 forceCurve = vec2;

                float radian = Mathf.Atan2(inputFire.Horizontal, inputFire.Vertical);

                //�e���\���̈ʒu�ɓ_���ړ�
                for (int i = 0; i < SIMULATE_COUNT; i++)
                {
                    
                    var t = 0.05f; // 0.2�b���Ƃ̈ʒu��\���B

                    
                    if (i * t < curvePoint)
                    {
                        xvar=0;
                        yvar=0;
                        zvar=t * forcestraight.z;
                        curvePointball = i;
                    }
                    else if (i * t >= curvePoint)
                    {
                            if (percentage == 0)
                            {
                                percentage = 0.00001f;
                            }
                            xvar = 0.3f* t * forceCurve.x * (1/(percentage * 0.01f)) * Mathf.Sin(radian)* (1-Mathf.Cos((float)Mathf.PI * (i * t - curvePoint) * simulateRotateSpeed));//radian��+90�␳����Ă邽�ߖ{����Cos����Sin
                            yvar = 0.3f*t * forceCurve.x * (1 / (percentage * 0.01f)) * Mathf.Cos(radian)* (1-Mathf.Cos((float)Mathf.PI * (i * t - curvePoint) * simulateRotateSpeed));
                            zvar = 0.5f*t * forceCurve.x * (1 / (percentage * 0.01f)) * Mathf.Sin((float)Mathf.PI *1.08f* (i * t - curvePoint) * simulateRotateSpeed);
                    }
                    
                    if (i == 0)
                    {
                        simuratePointList[i].transform.localPosition = _startPosition + new Vector3(xvar, yvar, zvar);
                    }
                    else
                if (i < SIMULATE_COUNT)
                    {
                        simuratePointList[i].transform.localPosition = simuratePointList[i-1].transform.localPosition + new Vector3(xvar, yvar, zvar);
                    }

                }
            }
        }
    }

    public float GetBendingAngle(float FireX , float FireY)
    {
        float radian=Mathf.Atan2(FireY,FireX);
        float degree = radian * Mathf.Rad2Deg;
        return bendingAngle =degree +90;
        //���ˎ��̂˂���p�x��6���̈ʒu����n�܂�InputFire�͂R���̈ꂩ��n�߂邽�߁{�X�O�ŕ␳
    }

   

    public void CurveFire()
    {
        Vector3 bulletSpawnPoint = bulletSpawn.transform.position;
        rb = Instantiate(curveBullet, bulletSpawnPoint, bulletSpawn.transform.rotation * Quaternion.Euler(bendingAngle, -90, 90)).GetComponent<Rigidbody>();
        LauncherSE();
        rb.AddForce(bulletSpawn.transform.forward*bulletSpeed, ForceMode.Impulse);
    }

    public void RefrectFire()
    {
        Vector3 bulletSpawnPoint = bulletSpawn.transform.position;
        rb=Instantiate(refrectBullet, bulletSpawnPoint, bulletSpawn.transform.rotation * Quaternion.Euler(0, -90, 90)).GetComponent<Rigidbody>();
        LauncherSE();
        rb.AddForce(bulletSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);

    }
    public Quaternion ClampRotation(Quaternion q, int mini, int max)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;
        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, mini, max);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
        return q;
    }

    private IEnumerator DelayMethod(int delayFrameCount, System.Action action)
    {
        for (var i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }

    public void LauncherSE()
    {
        playerSE.clip = launcherSE;
        playerSE.Play();
    }
    public void RunningSE()
    {
        PlayerSE.clip = runningSE;
        PlayerSE.Play();
    }
    public void StopRunningSE()
    {
        PlayerSE.Stop();
    }
}
  
   

