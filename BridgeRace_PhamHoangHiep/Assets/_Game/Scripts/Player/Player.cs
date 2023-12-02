using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BridgeRace{
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Player : BaseCharacter
{

    /*private void Start(){
        OnInit();
    }*/
    [SerializeField] private Rigidbody rbPlayer;
    [SerializeField] private FixedJoystick fixedJoystick;
    public override void OnInit(){
        base.OnInit();
        ChangeColor((ColorType)Random.Range(1,5));
        //this.transform.position = 
    }

    private void FixedUpdate(){
        rbPlayer.velocity = new Vector3(fixedJoystick.Horizontal * moveSpeed, rbPlayer.velocity.y, fixedJoystick.Vertical * moveSpeed);
        
        if(fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0){
            Transform.rotation = Quaternion.LookRotation(rbPlayer.velocity);
            Move();
            ChangeAnim(Constants.ANIM_RUN);
        } else {
            ChangeAnim(Constants.ANIM_IDLE);
        }
    }
   
    private void Move(){
        RaycastHit hit;
        Vector3 nextPoint = new Vector3(fixedJoystick.Horizontal*moveSpeed*Time.fixedDeltaTime+1f, 2, fixedJoystick.Vertical*moveSpeed*Time.fixedDeltaTime+1f) + Transform.position;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, stairLayer)){
            
            Stair stair = hit.collider.gameObject.GetComponent<Stair>();
            
            if(stair.color != this.color && this.BrickCount > 0){
                Transform.position = new Vector3(Transform.position.x, Transform.position.y + 0.2f, Transform.position.z);
                stair.ChangeColor(this.color);
                this.DropBrick(hit.collider.transform.position);
                stage.NewBrick(color);
            } else if(stair.color == this.color){
                Transform.position = new Vector3(Transform.position.x, Transform.position.y + 0.2f, Transform.position.z);
            }
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag(Constants.TAG_ENEMY)){
            Debug.Log("Enemy");
            //Drop all brick of object that have fewer bricks, the dropped brick is turned to gray
            DropBrick(other.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Constants.TAG_BRICK)){
            //Debug.Log("Brick");
            if(other.GetComponent<Brick>().color == this.color){
                CollectBrick();
            }
        }

        if(other.CompareTag(Constants.TAG_CHECKPOINT)){
            //If player meet the condition of the checkpoint, the checkpoint will be opened and player can play the next stage of the game
        }

        if(other.CompareTag(Constants.TAG_WINPOINT)){
            Debug.Log("Win");
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag(Constants.TAG_BRICK)){
            //Debug.Log("BrickExit");
        }
    }

    
    private void BuildStair(){
        //Drop Brick to build stair
        //Can drop on other player's stair  

    }

    

    
}
}