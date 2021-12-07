using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;

public class Dialouge_2 : MonoBehaviour
{
    public DialogueManager dm;
    public TextMeshProUGUI dialouge;
    public QD_DialogueDemo _dial;

    void OnTriggerEnter(Collider other)
    {
        dm.Dialogue.SetActive(true);
        _dial.handler.SetConversation("Ghost Two");
        _dial.SetText();
    }
    void OnTriggerExit(Collider other)
    {
       
    }
}
