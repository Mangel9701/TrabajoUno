using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalSpeed;
    public float maxMovement;
    public Vector2 screenCenter;

    // Start is called before the first frame update
    public CharacterController controller;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        float mouseMovement = rotationSpeed * (Input.mousePosition.x - screenCenter.x);
        Debug.Log(mouseMovement);

        if (mouseMovement < -maxMovement || mouseMovement > maxMovement)
        {
            transform.Rotate(new Vector3(0, maxMovement * Mathf.Deg2Rad, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, mouseMovement * Mathf.Deg2Rad, 0));
        }
    }
}

