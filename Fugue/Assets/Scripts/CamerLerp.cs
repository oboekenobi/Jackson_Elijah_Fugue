using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;


public class CamerLerp : MonoBehaviour
{

    [System.Serializable]
    public struct QD_MessageInfo
    {
        public int ID;
        public int NextID;
        public QD_NodeType Type;



        public QD_MessageInfo(int id, int nextID, QD_NodeType type)
        {
            ID = id;
            NextID = nextID;
            Type = type;
        }
    }


    public DialogueManager dm;
    public string convo;
    public DialogueCollider Da;
    public QD_DialogueDemo _dial;
    public QD_DialogueHandler dh;
    //public string conversation;
    public Transform LookPos;
    public GameObject _collider;
    public GameObject ColliderStart;
    public GameObject NPC;


    void Start()
    {
        dh = QD_DialogueHandler._instance;
        _dial = QD_DialogueDemo ._instance;
        dm = DialogueManager._instance;
    }

    void OnTriggerEnter(Collider other)
    {
        //_collider = other;

        dm.CurrentCollider = ColliderStart;
        //_collider = obj/GetComponent<GameObject>();
        _dial.ended = false;

        dm.nextSceneString = Da.NextScene;

        convo = Da.conversation;
        dm.Dialogue.SetActive(true);

        //conversationStart = conversation;
        //dm.moan.Play();
        _dial.handler.SetConversation(convo); 
        _dial.SetText();
        //dm.Into = true;
        ColliderStart.SetActive(false);
        dm.StartCoroutine(dm.Lerped());
        
        if(LookPos != null)
        {
            dm.NPC = LookPos;
        }
        if(NPC != null)
        {
            dm.NPC = LookPos;
            dm._npc = NPC;
        }
        
    }


    public void Update()
    {
        if (_dial.ended)
        {
            //dm.CurrentCollider = null;
            //dm.CurrentCollider.SetActive(false);
            //_collider = gameObject;
            //Collider = null;
            //_collider = null;
            //_collider = null;
            //conversationStart = null;
          
        }
    }


    // IEnumerator DoAThingOverTime(Color start, Color end, float duration) 
    // {
    // for (float t=0f;t<duration;t+=Time.deltaTime)
    //     {
    //         c = NPC.rend.material.color;
    //         float normalizedTime = t/duration;
    //         //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
    //         someColorValue = Color.Lerp(, end, normalizedTime);
    //         yield return null;
    //     }
    //     someColorValue = end; //without this, the value will end at something like 0.9992367
    // }

    

}

