using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using QuantumTek.QuantumDialogue;

//This class animates text being typed out
public class Demo_DialogueAnimation : MonoBehaviour
{
    public QD_Message ms;
    //Some public facing variables we'll need
    //Where our text will be typed into
    [SerializeField]
    private TextMeshProUGUI dialogueField;
    //Some lines of dialogue I'm using
    [SerializeField]
    public List<string> conversationBits = new List<string>();
    //How fast do we want these lines to type out?
    [SerializeField]
    private float charactersPerSecond;
    public GameObject MessageText;
    public bool scrollEnded;

    //Private int to track which line of dialogue to write from our list
    private int currentDialogueBit = 0;

    
    void Start()
    {
        //Play our first line of dialogue right away on start
        //AdvanceDialogue();
    }

    void Update()
    {
        //Anytime you hit "C" play the next line of dialogue
        /*  if (Input.GetKeyDown(KeyCode.C))
          {
              AdvanceDialogue();
          }*/
       
   

    }

    //This is the method to call to draw out our dialogue
    private void AdvanceDialogue()
    {
        //If we're out of range, set us back to 0
        currentDialogueBit = currentDialogueBit >= conversationBits.Count ? 0 : currentDialogueBit;
        //Get the current string of dialogue from out list
        string dialogueString = conversationBits[currentDialogueBit];
        //If our index is less than the amount of lines we have, then we can advance our dialogue
        if (currentDialogueBit < conversationBits.Count);
        {
            StartCoroutine(TypeOutDialogue(dialogueString));
        }
    }

    //This enumerator does all of the typing
    public IEnumerator TypeOutDialogue(string _dialogue)
    {
        //yield return new WaitForSeconds(1f);

       // MessageText.SetActive(true);

        //How many characters are in our string? String variables are essentially arrays of 'characters,'
        //hence why we can Access it like an array to get it's length
        int totalCharacters = _dialogue.Length;
        //Create a new string to add our characters to as it types out
        string currentText = "";
        //Modify your delay between characters based on how fast you want it to type out
        float typingDelay = 60 / charactersPerSecond * 0.1f;

        //This forloop loops through all of the characters in our dialogue string 
        for (int i = 0; i < totalCharacters; i++)
        {
            //Get the next character to add to our text
            string characterToAdd = _dialogue[i].ToString();
            //Wait a delay to simulate typing
            yield return new WaitForSeconds(typingDelay);
            //Add our current text and our new character and set it to our text field
            dialogueField.text = currentText + characterToAdd;
            //Set our current text to what we just wrote so we can add to it some more
            currentText = dialogueField.text;
        }
        //This just increases my List<string> index so I can get the next string
        currentDialogueBit += 1;

        yield return new WaitForEndOfFrame();

        scrollEnded = true;
        yield break;
    }
}
