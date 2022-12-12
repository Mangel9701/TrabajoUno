using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    // Start is called before the first frame update
  

    public float playerSpeed;
    private Vector2 screenCenter;
    private float mouseMovement;
    public float rotationSpeed;
    public float minMouseMovemnt;
    public int JumpStrength;
    private int verticalSpeed;
    private Animator anim;
    private bool isRunnning;
    public CharacterController CharacterController;

    void Start()
    {
       
          screenCenter = new Vector2(Screen.width / 2 , Screen.height / 2);

            anim = gameObject.GetComponent<Animator>();
           
    }

    // Update is called once per frame
    void Update()
    {
    /*
        float mouseMovement = Input.mousePosition.x - screenCenter.x;
        if(mouseMovement < -minMouseMovemnt || mouseMovement > minMouseMovemnt){
            transform.Rotate(new Vector3(0,rotationSpeed*mouseMovement,0));
        }
    */
         if (Input.GetKey("up") || Input.GetKey(KeyCode.W)  ){
          
           isRunnning=true;
            transform.position += transform.forward*playerSpeed*Time.deltaTime;
        }

              if (Input.GetKey("down") || Input.GetKey(KeyCode.S)  ){
   
        isRunnning=true;
            transform.position -= transform.forward*playerSpeed*Time.deltaTime;
        }

            if (Input.GetKey("right") || Input.GetKey(KeyCode.D)  ){
            
            transform.Rotate(new Vector3(0,rotationSpeed,0));
    
        }

           if (Input.GetKey("left") || Input.GetKey(KeyCode.A)  ){
            
            transform.Rotate(new Vector3(0,-rotationSpeed,0));
    
        }

     

     

         if ( Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S)  ){
       
            isRunnning=false;
      }

      if(isRunnning){
        anim.Play("Run");
      }else{
        anim.Play("Idle"); 
      }

    }
}
