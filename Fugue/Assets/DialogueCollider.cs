using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColliderDialogue", menuName = "ColliderDialogue")]
public class DialogueCollider : ScriptableObject
{

    public string conversation;
    public string NextScene;


    //public Transform NPC;
    //public GameObject collider;
    //public Transform Ghost;


    // public Transform Ghost;
    // public GameObject Collider;

    // if(GameObject.Find(Collider) != null)
    // {
    //     dm.Dialogue.SetActive(true);
    //     //conversationStart = conversation;
    //     dm.moan.Play();
    //     _dial.handler.SetConversation(conversation); 
    //     _dial.SetText();
    //     //dm.Into = true;
    //     dm.StartCoroutine(dm.Lerped());
    //     dm.NPC = Ghost;
    // }



}
