using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;

public class Book_Script : MonoBehaviour
{
    public QD_DialogueDemo _dm;
    public DialogueManager dm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            _dm.handler.SetConversation("Book Enterance"); 
            dm.Dialogue.SetActive(true);
        }
    }
}
