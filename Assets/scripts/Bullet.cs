using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject parentTurret;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyByTimeAlive",3);
        
      
       

    }

    private void destroyByTimeAlive()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        charControlProfe player = collision.gameObject.GetComponent<charControlProfe>();
       
    

        if (player != null) {
         
            player.healt -= 34;
           
        }

       

        if (collision.gameObject.tag != "TurretPart")
        {
            Destroy(gameObject);

        }
       
      




    }
}
