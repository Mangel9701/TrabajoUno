using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bala : MonoBehaviour
{
    [SerializeField] private float Velocidad;
    [SerializeField] private float DanoBala;
     public GameObject parentTorre;

    private void Update()
    {
        transform.position += transform.forward *Velocidad * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.root.name=="S_PlayerMove")
        S_PlayerMove player = collision.gameObject.GetComponent<S_PlayerMove>();

        if (player!=null)
        {

            player.TomaDano(DanoBala);

        }
        if (collision.gameObject != parentTorre)
        {
            Destroy(gameObject);
        }

        
    }
}
