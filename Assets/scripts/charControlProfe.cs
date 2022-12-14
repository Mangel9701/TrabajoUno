using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControlProfe : MonoBehaviour
{

    public bool isAlive;
    public int score;
    public float healt=100, walkingSpeed, runningSpeed, gravity, rotationSpeed, minMouseMovement, jumpStrength;
    public string characterName;
    public Vector3 verticalSpeed;
    public Vector2 screenCenter;
    public Animator animator;
    public CharacterController characterController;
    private bool wannaJump=false;
    // Start is called before the first frame update
    
    void Start()
    {
     
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (healt<=0) { 
            healt= 0;
        }

        if(verticalSpeed.y<=0 && characterController.isGrounded && !wannaJump){
            verticalSpeed.y=0;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded){
            verticalSpeed = jumpStrength * Vector3.up;
            wannaJump=true;
            animator.SetBool("jumping",true);

        }else if(characterController.isGrounded){
            wannaJump=false;
             animator.SetBool("jumping",false);
        }

        verticalSpeed += Physics.gravity * gravity;

       

        float mouseMovement = Input.mousePosition.x - screenCenter.x;

        if(mouseMovement <- minMouseMovement || mouseMovement > minMouseMovement){
            transform.Rotate(new Vector3(0,rotationSpeed * mouseMovement, 0));
        }
        Vector3 horizontalSpeed = Input.GetAxis("Vertical")*transform.forward;

        if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift)){
            horizontalSpeed *= runningSpeed;
        }else{
             horizontalSpeed *= walkingSpeed;
        }

        animator.SetFloat("speed",horizontalSpeed.magnitude);
        characterController.Move((horizontalSpeed + verticalSpeed)*Time.deltaTime);
    }
}
