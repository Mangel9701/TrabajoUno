using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public float speed;
    public int maxSpeed;
    private bool frenando=false;
    private int wichDirection;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward*speed*Time.deltaTime;
        
         if (Input.GetKey("up") || Input.GetKey(KeyCode.W)  ){
             speed+=0.1f;
             wichDirection=1;
             frenando=false;
        }else if (Input.GetKey("down") || Input.GetKey(KeyCode.S)  ){
             speed-=0.1f;
             wichDirection=-1;
             frenando=false;
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D)  ){
            
            transform.Rotate(new Vector3(0,rotationSpeed,0));
    
        }

           if (Input.GetKey("left") || Input.GetKey(KeyCode.A)  ){
            
            transform.Rotate(new Vector3(0,-rotationSpeed,0));
    
        }

        

    if ( Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp("down") || Input.GetKeyUp(KeyCode.S)  ){
       
        if(!frenando){
            frenando=true;
        }
       Debug.Log("frenando " + frenando);
          Debug.Log("wichDirection " + wichDirection);
       
    }

    if(frenando){
        speed-=wichDirection*0.2f;
        switch (wichDirection)
        {
            case 1:
              if(speed<0){
                    frenando=false;
                }
            break;

            case -1:
             if(speed>0){
                    frenando=false;
                }
            break;
            
            default:
            if(speed<0){
                    frenando=false;
                }
              break;
        }
      

    }
    
    if(speed>maxSpeed){
            speed=maxSpeed;
        }
        
    }
}
