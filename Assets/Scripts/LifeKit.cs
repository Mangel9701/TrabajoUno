using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeKit : MonoBehaviour
{
    public float rotationSpeed = 60.0f;
    public float healthAmount = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.name == "Jugador") {
            S_PlayerMove player = other.gameObject.GetComponent<S_PlayerMove>();
            player.Curar(healthAmount);

            Destroy(gameObject);
        }

    }

}