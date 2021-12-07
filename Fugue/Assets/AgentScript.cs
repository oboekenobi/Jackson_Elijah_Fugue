using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    public float playerDist;
    public Transform playerPos;
    public float Threshold;
    public float MaxDist;
    public Transform _agent;
    public bool isWalking;
    public Vector3 switchPos;
    public Animator _anim;
    public Vector3 playerPosition;
    public Vector3 angles;

    

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = Vector3.Distance(playerPos.position, transform.position);

        //transform.LookAt(target);




        playerPosition = playerPos.position;

        if(!isWalking)
        {

            //Vector3 point = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z);
            

            Quaternion LookRotation = Quaternion.LookRotation(playerPosition - transform.position);

            angles = LookRotation.eulerAngles;

            Vector3 point = new Vector3(0f, angles.y, 0f);

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, point, 2 * Time.deltaTime);
            _anim.SetBool("Walk", false);
            _anim.SetBool("idle", true);


        }

        if(isWalking)
        {
           _anim.SetBool("idle", false);
           _anim.SetBool("Walk", true);
        }


        // if (lockOnToggle == "yes")
        // {

        // Quaternion lookOnLook = Quaternion.LookRotation(enemy.transform.position - transform.position);
        
        // transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime);

        // }

   
        agent.SetDestination(target.position);
        

        if(playerDist >= Threshold)
        {
          //agent.SetDestination(_agent.position);
          agent.isStopped = true;
          isWalking = false;
          //transform.LookAt(playerPos.position);
        }
        if(playerDist <= Threshold)
        {
          agent.isStopped = false;
          isWalking = true;

        }

        //  if(playerDist <= MaxDist)
        // {

        //   isWalking = true;
        //   transform.LookAt(playerPos.position);
        // }
        // if(playerDist >= MaxDist)
        // {
        //   agent.SetDestination(target.position);

        // }

    
    }
}
 