using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControlProfe : MonoBehaviour
{

    public bool isAlive;
    public int score;
    public float healt=100, walkingSpeed, runningSpeed, gravity, rotationSpeed, minMouseMovement, jumpStrength;
    public float maxHealt = 100;
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
        Load();
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


   public void Save()
    {
        Debug.Log("Saving");
        PlayerPrefs.SetInt("CheckpointReached", 1);
        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        PlayerPrefs.SetFloat("zPos", transform.position.z);

    }

   public void Load()
    {

        if (PlayerPrefs.GetInt("CheckpointReached", 0) != 0)
        {

            float x = PlayerPrefs.GetFloat("xPos");
            float y = PlayerPrefs.GetFloat("yPos");
            float z = PlayerPrefs.GetFloat("zPos");

            transform.position = new Vector3(x, y, z);

        }



    }



}
