using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BridgeRace{
public class Enemy : BaseCharacter
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Vector3 destination;
    //[SerializeField] private Transform target;
    public bool IsDestination => Vector3.Distance(Transform.position, destination + (Transform.position.y - destination.y) * Vector3.up) < 0.1f;
    public override void OnInit(){
        base.OnInit();
        ChangeColor((ColorType)Random.Range(1,5));
        //this.transform.position = 
    }

    private void OnTriggeredEnter(Collider other){
        if(other.CompareTag(Constants.TAG_WINPOINT)){
            Debug.Log("Lose");
        }
    }
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag(Constants.TAG_PLAYER)){
            Debug.Log("Player");
            //Drop all brick of object that have fewer bricks, the dropped brick is turned to gray
            DropBrick(other.transform.position);
        }
    }

    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destination = position;
        //destination.y = 0;
        agent.SetDestination(position);
    }

    IState<Enemy> currentState;

    private void Update()
    {
        //agent.destination = target.position;
        
        if (currentState != null)
        {
            currentState.OnExecute(this);
            //check stair
            IsMoveable(Transform.position);
            Move();
        }
    }

    public void ChangeState(IState<Enemy> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    internal void MoveStop()
    {
        agent.enabled = false;
    }

    private void IsMoveable(Vector3 position){
        
    }

    private void Move(){
        RaycastHit hit;
        Vector3 nextPoint = new Vector3(moveSpeed*Time.deltaTime+1f, 2, moveSpeed*Time.deltaTime+1f) + Transform.position;

        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, stairLayer)){
            //Debug.Log("is Stair");
            Stair stair = hit.collider.gameObject.GetComponent<Stair>();
            
            if(stair.color != this.color && this.BrickCount > 0){
                Transform.position = new Vector3(Transform.position.x, Transform.position.y + 0.2f, Transform.position.z);
                stair.ChangeColor(this.color);
                this.DropBrick(hit.collider.transform.position);
            } else if(stair.color == this.color){
                Transform.position = new Vector3(Transform.position.x, Transform.position.y + 0.2f, Transform.position.z);
            }
        }
    }
}
}