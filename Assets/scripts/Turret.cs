using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    public Transform rotatingSphere;
    private GameObject player;
    public GameObject bullet;
    public Transform bulletOrigin;
    public float shootTime = 3;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
        Invoke("soot", shootTime);
     //  player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

      
      rotatingSphere.LookAt(player.transform.position + new Vector3(0,14f,0));
       
    }

    void shoot()
    {
        Invoke("soot", shootTime);
        GameObject bulletCopy = Instantiate(bullet, bulletOrigin.position, Quaternion.identity );
        bulletCopy.transform.LookAt(player.transform.position);
    }
}
