using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class S_PlayerMove : MonoBehaviour
{
    //el "protected" es privado para este script menos para las clases hijas

    public bool EstaVivo;
    public int Puntaje;
    public float Salud, Velocidad, gravedad, VelocidadRotacion,MovimientoMouseMin;
    public string Nombre;
    public Vector3 MovimientoHorizontal;
    public Vector3 VelocidadVertical;
    public Vector2 CentroPantalla;

    public CharacterController CharacterController;
    //no permite usar el rigidbody
    //public Rigidbody RB;
    public Collider Collider;

    public AudioSource Audio;


    private void Start()
    {
        CentroPantalla = new Vector2 (Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        //delta time asegura que se mueva a la velocidad por segundo y no por frame

        VelocidadVertical += Physics.gravity*gravedad*Time.deltaTime;

        float MovimientoMouse = Input.mousePosition.x - CentroPantalla.x;

        if (MovimientoMouse<MovimientoMouseMin || MovimientoMouse>MovimientoMouseMin)
        {
            transform.Rotate(new Vector3(0, VelocidadRotacion * MovimientoMouse, 0));
        }

        //el get axis da desde 1 a -1, 1=delante 0=nada -1=atras
        transform.position += Input.GetAxis("Vertical")*transform.forward * Velocidad * Time.deltaTime + VelocidadVertical; 

        #region Ejemplos

        /*
        Puntaje++;
        Puntaje += 1;
        Puntaje = Puntaje + 1;

        Puntaje--;
        Puntaje -= 1;

        Puntaje *= 2;
        Puntaje /= 2;

        EstaVivo = false;
        EstaVivo = true;

        Nombre = "Irene";
        
         //transform.localPosition = MovimientoHorizontal;
        //transform.localPosition = new Vector3(1,0,0);
        //transform.Position += new Vector3(1,0,0);
        //transform.Position += new Vector3(10,0,0);
         
         if (Input.GetKey(KeyCode.W)) 
        { 
            transform.position += transform.forward * Velocidad * Time.deltaTime + VelocidadVertical; 
        }
         
         */





        #endregion

    }

}
