using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrectBullet : MonoBehaviour
{
    //
    //RefrectBullet
    //



    Rigidbody rb;
    new Collider collider;
    int i = 0, destroyRefrectNumber=5;
    Vector3 lastPosition, direction;
    public AudioSource RefrectSE;
    public AudioClip refrectSE;
    
    public GameObject audio_ob;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.isTrigger = true;
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.position-lastPosition;
        if (direction.magnitude>0.1f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            transform.rotation *= Quaternion.AngleAxis(-90, Vector3.right);
        }
        lastPosition=transform.position;
    }

    public void BulletRefrectCondition()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Map")
        {
            REFRECTSE();
            collider.isTrigger=false;
            StartCoroutine(DelayMethod(1, () =>
            {
                collider.isTrigger = true;
            }));
            i++;
            if (i == destroyRefrectNumber)
            {
                Destroy(gameObject);
            }
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
    
    private IEnumerator DelayMethod(int delayFrameCount, System.Action action)
    {
        for (var i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
    public void REFRECTSE()
    {
        RefrectSE.clip = refrectSE;
        RefrectSE.Play();
    }
    
}

