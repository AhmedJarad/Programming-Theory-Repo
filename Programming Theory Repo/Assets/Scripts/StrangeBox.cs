using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeBox : Box
{// INHERITANCE
    bool IsChanged = false;
public override void Move()
    {// POLYMORPHISM
        rb.AddRelativeForce(-Vector3.forward * speed,ForceMode.Acceleration);
        if (IsChanged == false)
        {
            StartCoroutine("ChangePos");
        }
       
       
    }
    IEnumerator ChangePos()
    {
        yield return new WaitForSeconds(1);
        int RandomN = Random.Range(1, 3);
        if (RandomN==1) {
            if (right)
            {
                transform.position = new Vector3(-2.77f, transform.position.y, transform.position.z);

            }
           if (left) 
            {
                transform.position = new Vector3(2.77f, transform.position.y, transform.position.z);

            }

            if (center) 
            {

                transform.position = new Vector3(2.77f, transform.position.y, transform.position.z);

            }else if(RandomN == 2)
            {
                if (right)
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);

                }
                if (left)
                {
                    transform.position = new Vector3(0f, transform.position.y, transform.position.z);

                }

                if (center)
                {

                    transform.position = new Vector3(-2.77f, transform.position.y, transform.position.z);

                }
            }
        
        
        
        }
        IsChanged = true;
    }
}
