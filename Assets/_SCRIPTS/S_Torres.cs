using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Torres : MonoBehaviour
{
    private Transform EsferaRotadora;
    private S_PlayerMove Jugador;
    [SerializeField] private GameObject Bala;
    [SerializeField] private Transform SocketBala;
    [SerializeField] private float VelocidadDisparo;
    private GameObject CopiaBala;


    public float shootTime = 3;
    public AudioSource BulletAudioSource;
    public AudioClip BulletSound;
    private bool isNear = false;

    public int activationDistance = 24;



    void Start()
    {
        #region Ejemplos
        //Jugador = GameObject.FindObjectOfType<S_PlayerMove>();
        //Jugador = GameObject.FindGameObjectWithTag("Jugador").transform; ó
        //Jugador = GameObject.Find("Jugador").transform;
        #endregion

        Jugador = GameObject.Find("Jugador").GetComponent<S_PlayerMove>();
        EsferaRotadora = this.transform;

        Invoke("Disparo",VelocidadDisparo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, Jugador.transform.position) < activationDistance)
        {
            isNear = true;
            EsferaRotadora.LookAt(Jugador.transform.position + new Vector3(0, 1.4f, 0));
        }
        else
        {
            isNear = false;
        }

        
    }

    private void Disparo()
    {
        if (isNear)
        {
            CopiaBala = Instantiate(Bala, SocketBala.position, Quaternion.identity); //quaternion.identity para obtener la rotacion perse (por defecto) de la bala
            BulletAudioSource.PlayOneShot(BulletSound);
            CopiaBala.GetComponent<S_bala>().parentTorre = gameObject;

            CopiaBala.transform.LookAt(Jugador.transform.position + new Vector3(0, 1.4f, 0));
            Invoke("Disparo", 3);
        }
        

    }


  /*  void Shoot()
    {
        Invoke("Shoot", shootTime);

        if (isNear)
        {
            Debug.Log("is near");
            BulletAudioSource.PlayOneShot(BulletSound);
            GameObject bulletCopy = Instantiate(Bala, SocketBala.position, Quaternion.identity);
            bulletCopy.GetComponent<Bullet>().parentTurret = gameObject;
            bulletCopy.transform.rotation = SocketBala.rotation;

        }


        // bulletCopy.transform.LookAt(player.transform.position );
    }*/

    /*private float Multiplicar(float PrimerNum, float SegundoNum)
    {
        PrimerNum*= SegundoNum;
        return PrimerNum;
    }*/
}
