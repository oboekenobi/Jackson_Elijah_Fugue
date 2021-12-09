using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
    public DialogueManager _dm;
    // Start is called before the first frame update
    void Start()
    {
        _dm = DialogueManager._instance;
    }


    private void OnTriggerEnter(Collider other) 
    {
        _dm.canOpenGate = true;
    }



    
}
