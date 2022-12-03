using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    // Start is called before the first frame update
  
    private CharacterController controller;
    public float playerSpeed;
    private Vector2 screenCenter;
    private float mouseMovement;
    public float rotationSpeed;
    public float minMouseMovemnt;

    void Start()
    {
          controller = gameObject.AddComponent<CharacterController>();
          screenCenter = new Vector2(Screen.width / 2 , Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {

        float mouseMovement = Input.mousePosition.x - screenCenter.x;
        if(mouseMovement < -minMouseMovemnt || mouseMovement > minMouseMovemnt){
            transform.Rotate(new Vector3(0,rotationSpeed*mouseMovement,0));
        }
         if (Input.GetKey("up") || Input.GetKey(KeyCode.W)  ){
   
        
            transform.position += transform.forward*playerSpeed*Time.deltaTime;
        }

              if (Input.GetKey("down") || Input.GetKey(KeyCode.S)  ){
   

            transform.position -= transform.forward*playerSpeed*Time.deltaTime;
        }
    }
}
