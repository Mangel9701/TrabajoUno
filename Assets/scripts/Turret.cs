using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform rotatingSphere;
    public GameObject player;
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
    }
}
