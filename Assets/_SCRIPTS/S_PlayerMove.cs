using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class S_PlayerMove : MonoBehaviour
{
    //el "protected" es privado para este script menos para las clases hijas
    [Header("Detalles Personaje")]
    [Space]
    public string Nombre;
    public bool EstaVivo;
    public int Puntaje;
    public float Salud;
    private float SaludLlena = 100f;
    public float Puntuacion;


    [Header("Movimiento Personaje")]
    [Space]
    [SerializeField] private Vector2 CentroPantalla;
    [SerializeField] private float FuerzaSalto;
    public float VelocidadCaminar, VelocidadCorrer, gravedad, FactorVelocidad;
    private Vector3 VelocidadVertical, VelocidadHorizontal;

    private float MovimientoMouse;

    [Header("Mouse")]
    [Space]
    public float VelocidadRotacion;
    public float MovimientoMouseMin;

    [Header("Requeridos")]
    [Space]
    public CharacterController CharacterController;
    public AudioSource FuenteAudio;
    public AudioClip SonidoMoneda;
    public AudioSource SonidoPasos;
    public Animator Animador;
    public Image Corazon;
    public TextMeshProUGUI TextoPuntuacion;
    public Image[] Corazones;


    private void Start()
    {
        CentroPantalla = new Vector2 (Screen.width / 2, Screen.height / 2);
    }

    private void FixedUpdate()
    {
        #region Movimiento

        VelocidadHorizontal = Input.GetAxis("Vertical") * transform.forward;
        
        //delta time asegura que se mueva a la velocidad por segundo y no por frame
        VelocidadVertical += Physics.gravity*gravedad; //*Time.deltaTime
        

        MovimientoMouse = VelocidadRotacion * (Input.mousePosition.x - CentroPantalla.x);

        if (MovimientoMouse <- MovimientoMouseMin || MovimientoMouse > MovimientoMouseMin)
        {
            transform.Rotate(new Vector3(0, MovimientoMouseMin * Mathf.Deg2Rad, 0));
        }else
        {
            transform.Rotate(new Vector3(0, MovimientoMouse * Mathf.Deg2Rad, 0));
        }

        if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            VelocidadHorizontal *= VelocidadCorrer; //* Time.deltaTime
        }
        else
        {
            VelocidadHorizontal  *= VelocidadCaminar;
        }

        CharacterController.Move( VelocidadHorizontal + VelocidadVertical);

        //en la animacion has exit time es que ejecute la animacion tras haber terminado la anterior
        //magnitud es la longitud del vector(velocidadH)
        Animador.SetFloat("Velocidad", VelocidadHorizontal.magnitude*FactorVelocidad); //* Time.deltaTime

        if (Input.GetKeyDown(KeyCode.Space) && CharacterController.isGrounded) //con el is grounded nos aseguramos que el personaje este tocando el piso 
        {
            VelocidadVertical = FuerzaSalto * Vector3.up; //mide uno hacia arriba en el eje Y
            Animador.SetBool("Salto",true);

        }else if (CharacterController.isGrounded) 
        {
            Animador.SetBool("Salto", false);//si no esta saltando pero si en el piso
        }

        #endregion

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


        //el get axis da desde 1 a -1, 1=delante 0=nada -1=atras
        // este ya no es necesario por el uso del Character Controler transform.position += Input.GetAxis("Vertical")*transform.forward * Velocidad * Time.deltaTime + VelocidadVertical;


        //float MovimientoMouse = Input.mousePosition.x - CentroPantalla.x;

        /*if (MovimientoMouse<MovimientoMouseMin || MovimientoMouse>MovimientoMouseMin)
        {
            transform.Rotate(new Vector3(0, VelocidadRotacion * MovimientoMouse, 0));
        }*/

        //public Collider Collider; no se usa porque el controller ya viene con uno
        //no permite usar el rigidbody
        //public Rigidbody RB;



        #endregion

        SonidoPasos.volume = Mathf.Abs(Input.GetAxis("Vertical"));
        //la longitud de vertical siempre es de 1 a -1 absoluto = a 1 cuando nos movamos

    }

    public void TomaDano(float dano) 
    {
        if (Salud >= 0)
        {
            Salud -= dano;
        }
        //Corazon.fillAmount = Salud / SaludLlena;
        foreach (var item in Corazones)
        {
            item.fillAmount = Salud / SaludLlena;
        }

    }

    private void Update()
    {
        if (Salud <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("Deber_2");
            //SceneManager.LoadScene(0); indice segun el build scene
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
            if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Puntaje += 5;
            TextoPuntuacion.text = $"Puntuacion: {Puntaje}";
            //FuenteAudio.clip = SonidoMoneda;
            //FuenteAudio.Play();
            FuenteAudio.PlayOneShot(SonidoMoneda);//esto pone play al sonido que sea que este en el source
        }
    }
}
