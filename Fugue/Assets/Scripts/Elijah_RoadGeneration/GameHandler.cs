using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;

public class GameHandler : MonoBehaviour
{
    public static GameHandler _instance;

    //public UnityEvent OnClicked;
    public GameObject prefab;

    public bool canClone;
    public DialogueManager dm;
    public RoadHandler previousRoad;
    public RoadHandler currentRoad;
    public bool hasStarted;
    public bool cafe;
    public bool car;
    public bool intro;
    public bool house;
    public bool swing;
    public QD_DialogueDemo _dial;
    public GameObject Dialogue;
    public GameObject MiaWalk;



    private void Start()
    {
        //Instantiate(prefab, new Vector3(39.84F, 1.18F, -46), Quaternion.identity);
        //CreateRoadSection();
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        StartRoad();

        ResetCamera();

        //Instantiate(prefab, new Vector3(29.84F, 1.18F, -46), Quaternion.identity);
    }


    public void CreateRoadSection()
    {
        GameObject go = Instantiate(prefab, new Vector3(39.84F, 1.18F, 18.2F), Quaternion.identity);
        //currentRoad = go.GetComponent<RoadHandler>();
        canClone = true;
        //previousRoad = currentRoad;
        //currentRoad.canDestroy = true;
        if(hasStarted)
        {
            previousRoad = currentRoad;
            previousRoad.canDestroy = true;
        }
        hasStarted = true;
        //previousRoad.canDestroy = true;
        //previousRoad = currentRoad;
    }

    public void CloneRoad()
    {
        GameObject go = Instantiate(prefab, new Vector3(39.84F, 1.18F, 18.2F), Quaternion.identity);
        canClone = false;



        if (currentRoad == null)
        {
            currentRoad = go.GetComponent<RoadHandler>();
            return;
        } 

        previousRoad = currentRoad;
        previousRoad.canDestroy = true;

        

        //previousRoad = currentRoad;

        //currentRoad = go.GetComponent<RoadHandler>();
       
        //previousRoad.DestroyRoadChunk();

    }
    public void StartRoad()
    {
        GameObject go = Instantiate(prefab, new Vector3(39.84F, 1.18F, -46), Quaternion.identity);
        canClone = false;



        // if (currentRoad == null)
        // {
        //     currentRoad = go.GetComponent<RoadHandler>();
        //     return;
        // }

        //previousRoad = currentRoad;

        previousRoad = go.GetComponent<RoadHandler>();
        //previousRoad = currentRoad;
        //previousRoad.canDestroy = true;
        //previousRoad.DestroyRoadChunk();

    }

    public GameObject startingCam;
    public GameObject carCam;
    public GameObject cafeCam;
    public GameObject houseCam;
    public GameObject swingCam;
    public GameObject miaSwing;

    public Transform miaHead;
    public Transform headLook;

    private void Update()
    {
        miaHead.LookAt(headLook);
        if(car == true)
        {
           CarSwitch();
        }
        if(cafe == true)
        {
           CafeSwitch();
           //dm.Dialogue.SetActive(true);
        }
        if(intro == true)
        {
           IntroSwitch();
        }
        if(house == true)
        {
           HouseSwitch();
        }
        if(swing == true)
        {
           SwingSwitch();
        }
    }


    public void CarSwitch()
    {
        carCam.SetActive(true);
           startingCam.SetActive(false);
           houseCam.SetActive(false);
           swingCam.SetActive(false);
           cafeCam.SetActive(false);
           car = false;
           
    }

    public void SwingSwitch()
    {
        carCam.SetActive(false);
           houseCam.SetActive(false);
           swingCam.SetActive(true);
           startingCam.SetActive(false);
           cafeCam.SetActive(false);
           miaSwing.SetActive(true);
           swing = false;
           MiaWalk.SetActive(false);
    }

    public void ResetCamera()
    {
        carCam.SetActive(false);
        houseCam.SetActive(false);
        swingCam.SetActive(false);
        startingCam.SetActive(true);
        cafeCam.SetActive(false);
        miaSwing.SetActive(false);
    }

    public void HouseSwitch()
    {
        carCam.SetActive(false);
           houseCam.SetActive(true);
           swingCam.SetActive(false);
           startingCam.SetActive(false);
           cafeCam.SetActive(false);
           miaSwing.SetActive(false);
           house = false;
    }
    public void CafeSwitch()
    {
        carCam.SetActive(false);
        houseCam.SetActive(false);
        swingCam.SetActive(false);
        startingCam.SetActive(false);
        cafeCam.SetActive(true);
        cafe = false;
        // _dial.SetText();
        // _dial.ended = false;
        // dm.conversationState = true;
        // Cursor.lockState = CursorLockMode.None;
        // Dialogue.SetActive(true);
        // _dial.handler.SetConversation(mia);
    }

    public void IntroSwitch()
    {
        carCam.SetActive(false);
           houseCam.SetActive(false);
           swingCam.SetActive(false);
           startingCam.SetActive(true);
           cafeCam.SetActive(false);
           //dm.sceneFinished = true;
           intro = false;
    }
}
