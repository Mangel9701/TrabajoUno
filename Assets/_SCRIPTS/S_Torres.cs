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
        EsferaRotadora.LookAt(Jugador.transform.position + new Vector3(0,1.4f,0));
    }

    private void Disparo()
    {
        CopiaBala= Instantiate(Bala,SocketBala.position, Quaternion.identity); //quaternion.identity para obtener la rotacion perse (por defecto) de la bala

        CopiaBala.GetComponent<S_bala>().parentTorre = gameObject;

        CopiaBala.transform.LookAt(Jugador.transform.position + new Vector3(0, 1.4f, 0));
        Invoke("Disparo", 3);

    }

    /*private float Multiplicar(float PrimerNum, float SegundoNum)
    {
        PrimerNum*= SegundoNum;
        return PrimerNum;
    }*/
}
