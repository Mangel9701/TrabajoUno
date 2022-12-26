using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Torres : MonoBehaviour
{
    [Header("Detalles")]
    [Space]

    private Transform EsferaRotadora;
    private S_PlayerMove Jugador;

    [SerializeField] private float VelocidadDisparo = 1;
    [SerializeField] private float OffsetAttackRangeX = 1;
    [SerializeField] private float OffsetAttackRangeZ = 1;
    public float shootTime = 3;

    [Header("Requeridos")]
    [Space]

    [SerializeField] private AudioSource BulletAudioSource;
    [SerializeField] private AudioClip BulletSound;
    [SerializeField] private GameObject Bala;
    [SerializeField] private Transform SocketBala;
    [SerializeField] private ParticleSystem Explosion;
    public int activationDistance = 24;

    private bool isNear = false;
    private GameObject CopiaBala;

    void Start()
    {
        Jugador = GameObject.Find("Jugador").GetComponent<S_PlayerMove>();
        EsferaRotadora = this.transform;

        StartCoroutine("Disparo");
    }

    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, Jugador.transform.position) < activationDistance)
        {
            isNear = true;
            EsferaRotadora.LookAt(Jugador.transform.position + new Vector3(0, 1.4f, 0));
            Debug.DrawLine(transform.position, Jugador.transform.position, Color.red);
        }
        else
        {
            isNear = false;
            Debug.DrawLine(transform.position, Jugador.transform.position, Color.green);
        }      
    }

    private IEnumerator Disparo()
    {
        while(true) {
            if (isNear)
            {
                CopiaBala = Instantiate(Bala, SocketBala.position, Quaternion.identity); //quaternion.identity para obtener la rotacion perse (por defecto) de la bala
                BulletAudioSource.PlayOneShot(BulletSound);
                CopiaBala.GetComponent<S_bala>().parentTorre = gameObject;

                CopiaBala.transform.LookAt(Jugador.transform.position + new Vector3(Random.Range(-OffsetAttackRangeX, OffsetAttackRangeX), 1.4f, Random.Range(-OffsetAttackRangeZ, OffsetAttackRangeZ)));
            }
            
            yield return new WaitForSeconds(3f / VelocidadDisparo);
        }
    }

    #region Explosion
    public void Explotar()
    {
        if (Explosion!=null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "RocaCayendo")
        {
            Explotar();
            BulletAudioSource.PlayOneShot(BulletSound);
        }
    }

    #endregion


    #region Ejemplos
    //Jugador = GameObject.FindObjectOfType<S_PlayerMove>();
    //Jugador = GameObject.FindGameObjectWithTag("Jugador").transform; �
    //Jugador = GameObject.Find("Jugador").transform;

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

    #endregion


}
