using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    public Transform rotatingSphere;
    private GameObject player;
    public GameObject bullet;
    public Transform bulletOrigin;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
     //  player = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

      
      rotatingSphere.LookAt(player.transform.position + new Vector3(0,14f,0));
        shoot();
    }

    void shoot()
    {

        GameObject bulletCopy = Instantiate(bullet, bulletOrigin.position, Quaternion.identity );
        bulletCopy.transform.LookAt(player.transform.position);
    }
}
