using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Turret : MonoBehaviour
{

    public Transform rotatingSphere;
    private GameObject player;
    public GameObject bullet;
    public Transform bulletOrigin;
    public int activationDistance = 24;
    public float shootTime = 3;
    private bool isNear = false;
    public AudioClip BulletSound;
    public AudioSource BulletAudioSource;

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
        Invoke("Shoot", shootTime);
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < activationDistance)
        {
            isNear = true;
            rotatingSphere.LookAt(player.transform.position + new Vector3(0, 100f, 0));
        }
        else
        {
            isNear = false;
        }


      
      

       
       
    }

    void Shoot()
    {
        Invoke("Shoot", shootTime);
      
        if (isNear) {
            Debug.Log("is near");
            BulletAudioSource.PlayOneShot(BulletSound);
            GameObject bulletCopy = Instantiate(bullet, bulletOrigin.position, Quaternion.identity);
            bulletCopy.GetComponent<Bullet>().parentTurret = gameObject;
            bulletCopy.transform.rotation = bulletOrigin.rotation;
            
        }
       
     
       // bulletCopy.transform.LookAt(player.transform.position );
    }
}
