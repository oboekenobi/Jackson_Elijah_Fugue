using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseTrigger : MonoBehaviour
{
    public DialogueManager dm;

    public void Start()
    {
        dm = DialogueManager._instance;
    }

    private void OnTriggerEnter(Collider other) 
    {
        dm.StartCoroutine(dm.TransitionFromScene());
        dm.nextSceneString = ("intro");
        dm.conversationState = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
