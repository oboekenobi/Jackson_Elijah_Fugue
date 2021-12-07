using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    public Transform Head;
    private Quaternion Defaultpos;
    public TextMeshProUGUI dialouge;
    public RaycastHit hit;
    public GameObject ghost;
    public GameObject hitObject;
    public AudioSource gameMusic;
    public GameObject RaySelection;
    public bool interactable = false;
    public Camera mainCamera;
    public DialogueManager dm;


    void Start()
    {
        gameMusic.Play();
    }
   
    
    void Update()
    {

        /*Transform cam = Camera.main.gameObject.transform;*/
 


        if (!dm.conversationState)
        {
            if (hitObject != null && hitObject.tag == "Interactable")
            {
                RaySelection.SetActive(true);
            }
            else
            {
                RaySelection.SetActive(false);
            }
        }
     
          
       

            var dist = Vector3.Distance(target.position, Head.position);
        if (dist < 3)
        {
            Head.LookAt(target);
        }
        else
        {
            Head.rotation = Quaternion.Lerp(Head.rotation, Defaultpos, Time.deltaTime * 1);
        }


    }
    void FixedUpdate()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (!Physics.Raycast(ray, out hit, 2))
        {
            hitObject = (null);
        }
        else
        {
            hitObject = hit.transform.gameObject;
        }
    }

}
