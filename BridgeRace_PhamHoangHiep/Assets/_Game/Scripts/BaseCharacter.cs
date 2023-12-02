using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class BaseCharacter : ColorObject
{
    [SerializeField] public GameObject brickRenderPrefab;
    [SerializeField] public GameObject brickPrefab;
    [SerializeField] public Transform stackPoint;
    
    [SerializeField] public float moveSpeed;
    [SerializeField] public Animator anim;
    
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask stairLayer;
    public List<GameObject> brickStack; //brickRenderPrefab
    public int BrickCount => brickStack.Count;
    public Transform Transform => transform;
    public string animName;
    public Stage stage;
    public override void OnInit(){
        brickStack = new List<GameObject>();
        ChangeAnim(Constants.ANIM_IDLE);
    }

    public void CollectBrick(){
        //Add brick which is the same color with the player or is gray to bricks list
        GameObject brickRender = Instantiate(brickRenderPrefab, stackPoint);
        brickRender.GetComponent<Brick>().ChangeColor(this.color);
        Debug.Log(brickRender.GetComponent<Brick>().color);
        brickStack.Add(brickRender);
        SortBrick();
    }

    public void DropBrick(Vector3 dropPoint){
        //Remove one brick from bricks list
        if(BrickCount > 0){
            GameObject brick = brickStack[BrickCount - 1];
            brickStack.Remove(brick);
            Destroy(brick);
            //brick.transform.parent = null;
            //brick.transform.position = dropPoint;
        }
    }

    public void DropAllBricks(Vector3 dropPoint){
        //Remove all brick from bricks list
        while(BrickCount > 0){
            DropBrick(dropPoint);
            SpawnBricksOnDrop();
        }
    }

    public void SortBrick(){
        for(int i = 0; i < BrickCount; i++){
            brickStack[i].transform.localPosition = new Vector3(0, i * Constants.BRICK_HEIGHT, 0);
        }
    }

    public void SpawnBricksOnDrop(){
        
    }

    public void ChangeAnim(string animName){
        if(this.animName == null){
            this.animName = animName;
            anim.SetTrigger(this.animName);
        }
        if (this.animName != animName)
        {
            anim.ResetTrigger(this.animName);
            this.animName = animName;
            anim.SetTrigger(this.animName);
        }
    }
}
}