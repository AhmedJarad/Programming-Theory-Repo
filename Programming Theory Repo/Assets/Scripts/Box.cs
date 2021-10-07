using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{[HideInInspector]
    public float speed =25;
    bool IsGoodBox;
    public int BoxValue;
    protected Rigidbody rb;
    private float zBoundToDestroy= -5.53f;
    protected bool left, center, right;
    private float a;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomPosSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        BoundDestroy();

    }
    void RandomPosSpawner()
    {// ABSTRACTION
        transform.position = RandomPos();
    }
    Vector3 RandomPos()
    {// ABSTRACTION
        int randomNumber=  Random.Range(1, 4);
        Vector3 pos;
        switch (randomNumber)
        {
            case 1:
              pos= new Vector3(0, GameManager.Instance.RandomIntBetweenInc(1.29f, 1.29f*2), 9.873f);
                center = true;
                left = false;
                right = false;
                break;

            case 2:
                pos = new Vector3(-2.77f, GameManager.Instance.RandomIntBetweenInc(1.29f, 1.29f * 2), 9.873f);
                center = false;
                left = true;
                right = false;
                break;

            case 3:
                pos = new Vector3(2.77f, GameManager.Instance.RandomIntBetweenInc(1.29f, 1.29f * 2), 9.873f);
                center = false;
                left = false;
                right = true;
                break;

            default:
                pos = new Vector3(0, GameManager.Instance.RandomIntBetweenInc(1.29f, 1.29f * 2), 9.873f);
                center = true;
                left = false;
                right = false;
                break;

        }
        return pos;
  
    }
    void BoundDestroy()
    {// ABSTRACTION
        if (transform.position.z < zBoundToDestroy)
        {
            Destroy(gameObject);
        }
    }
   public virtual void  Move()
    {
        rb.AddRelativeForce(-Vector3.forward*speed);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            a -= Time.deltaTime;
            if (a < 0.1)
            {
                Destroy(gameObject);
                a = 3;
            }
   
        }
        if (collision.collider.CompareTag("MovingFloor")){
            Move();
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Basket"))
        {
         GameObject Basket= other.transform.gameObject;
            //  rb.move;
       transform.position=Vector3.MoveTowards(transform.position, Basket.transform.position,1);
            Destroy(gameObject,2);
        }
    }
}
