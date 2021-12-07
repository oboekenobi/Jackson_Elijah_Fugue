using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuantumTek.QuantumDialogue;
using QuantumTek.QuantumDialogue.Demo;


public class DialogueManager : MonoBehaviour
{
    public bool conversationState = false;
    private Quaternion _targetRotation1 = Quaternion.identity;
    private Quaternion _targetRotation2 = Quaternion.identity;
    private Quaternion _startRotation = Quaternion.identity;
    public Transform playerCamera;
    public Transform NPC;
    public GameObject Dialogue;
    public float turningRate = 1f;
    public AudioSource moan;
    public QD_DialogueDemo _dm;
    public static DialogueManager _instance;
    [SerializeField]
    public Transform mainCamera;
    public Quaternion StartPos;
    public bool hasLerped;
    public Transform playerController;
    public bool Into = false;
    public bool back = false;
    public bool canMove = false;
    public Vector2 mousePos;
    public Vector3 CalcPos;
    public Quaternion Calced;
    public Quaternion Cal;
    public bool LerpToMouse = false;
    public bool _lerped = false;

    public bool playLerpSequence = false;
    int currentPosition = 0;
    public float angle;
    public float anglex;
    public GameObject CurrentCollider;
    public bool fadeOut;
    public bool fadeIn;
    public bool fadeIns;
    public float fadeSpeed;
    public GameObject _npc;

    public GameObject ParentC;

    public List<GameObject> fadeOutObjects = new List<GameObject>();
    
    //public GameObject[] fadeOutObjects = new GameObject[transform.childCount];
    //public GameObject[] fadeOutObjects;

    public bool fadeOuts;

    public float AngleAxisFreeze;

    public FirstPersonLook firstPerson;

    public string nextSceneString;

    private GameHandler _gameHandler;
    
    //fadeOutObjects = ParentC.Cast<Transform>().Select(t=>t.gameObject).ToArray();

    public void FadeOutObject()
    {
        fadeOut = true;
    }

    public void FadeInObject()
    {
        fadeIn = true;
    }

     public void FadeOutObjects()
    {
        fadeOuts = true;
    }

    public void FadeInObjects()
    {
        fadeIns = true;
    }


    //public CamerLerp Cl;
   
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        

        GetChildRecursive(ParentC);

        RenderSettings.fogColor = new Color(0.19f, 0.05f, 0.07f, 1f);

        RenderSettings.fogDensity = 0.15f;
      
    }

    void Start()
    {
        _gameHandler = GameHandler._instance;
    }

    private void GetChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;

            foreach (Transform child in obj.transform)
            {
                if (null == child)
                    continue;
                //child.gameobject contains the current child you can do whatever you want like add it to an array
                fadeOutObjects.Add(child.gameObject);
                GetChildRecursive(child.gameObject);
            }
    }
        
    

    // Start is called before the first frame update
  
    private bool StayStill;

    public GameObject directionalLight;
    // Update is called once per frame
    void Update()
    {
        
       
        

        
        if(fadeIns)
       {
            //float lightAmount = directionalLight.GetComponent<Light>().intensity + (fadeSpeed * Time.deltaTime);
            
            //directionalLight.GetComponent<Light>().intensity = lightAmount;

        //     float fadeamounts = RenderSettings.fogColor.a + (fadeSpeed * Time.deltaTime);
        //    RenderSettings.fogColor = new Color(fadeamounts, fadeamounts, fadeamounts, fadeamounts);
           
           foreach(GameObject go in fadeOutObjects)
           {

               if (go.GetComponent<MeshRenderer>() != null)
               {
                   Color objectColor = go.GetComponent<Renderer>().material.color;
                    float fadeamount = objectColor.a + (fadeSpeed * Time.deltaTime);
                        objectColor = new Color(fadeamount, fadeamount, fadeamount, fadeamount);
                            go.GetComponent<Renderer>().material.color = objectColor;
                            if(objectColor.a >= 1)
                            {
                                fadeIns = false;
                                
                            }
               }

            
               
           }
        
       }






        if(fadeOuts)
       {
           
           float lightAmount = directionalLight.GetComponent<Light>().intensity - (fadeSpeed * Time.deltaTime);
            
           directionalLight.GetComponent<Light>().intensity = lightAmount;


            float fadeamountsr = RenderSettings.fogColor.r - (fadeSpeed * Time.deltaTime);
            float fadeamountsg = RenderSettings.fogColor.g - (fadeSpeed * Time.deltaTime);
            float fadeamountsb = RenderSettings.fogColor.b - (fadeSpeed * Time.deltaTime);
           RenderSettings.fogColor = new Color(fadeamountsr, fadeamountsg, fadeamountsb, 1);
           
           foreach(GameObject go in fadeOutObjects)
           {

               if (go.GetComponent<MeshRenderer>() != null)
                {
                    Color objectColor = go.GetComponent<Renderer>().material.color;
                    float fadeamount = objectColor.a - (fadeSpeed * Time.deltaTime);
                        objectColor = new Color(fadeamount, fadeamount, fadeamount, fadeamount);
                            go.GetComponent<Renderer>().material.color = objectColor;
                            if(objectColor.a <= 0.1)
                            {
                                fadeOuts = false;
                                
                            }
                }
            
               
           }
        
       }

       if(fadeOut)
       {
           Color objectColor = _npc.GetComponent<Renderer>().material.color;

           float fadeamount = objectColor.a - (fadeSpeed * Time.deltaTime);

           objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeamount);
           _npc.GetComponent<Renderer>().material.color = objectColor;
           if(objectColor.a <= 0)
           {
               fadeOut = false;
           }
       }
       if(fadeIn)
       {
           Color objectColor = _npc.GetComponent<Renderer>().material.color;
           float fadeamount = objectColor.a + (fadeSpeed * Time.deltaTime);
           
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeamount);
           _npc.GetComponent<Renderer>().material.color = objectColor;
           if(objectColor.a >= 0.70)
           {
               fadeIn = false;
           }

        

       }

       if(nextSceneString == "intro")
       {
           sceneFinished = true;
           //nextSceneString = ("");
          
       }


    }
    
    

    public bool sceneFinished;
    private Quaternion targetCam;
    private Quaternion targetChar;
    private void FixedUpdate()
    {
        

        if (Into)
        {
            
            if(NPC != null)
            {
                Vector3 pointPosCamera = NPC.position - playerCamera.transform.position;
                // Quaternion pointPosCameraRotate = new Vector3(pointPosCamera.x, 0, 0);
                Quaternion destCamera = Quaternion.LookRotation(pointPosCamera);
                Quaternion targetCamera = Quaternion.Euler(destCamera.eulerAngles.x, 0, 0);
                targetCam = targetCamera;
                

                playerCamera.transform.localRotation = Quaternion.Slerp(playerCamera.transform.localRotation, targetCamera, 2 * Time.deltaTime);

                Vector3 pointPosCharacter = NPC.position - Character.transform.position;
                //Vector3 pointPosCharacterRotate = new Vector3(0, pointPosCharacter.y, 0);
                Quaternion destCharacter = Quaternion.LookRotation(pointPosCharacter);
                Quaternion targetCharacter = Quaternion.Euler(new Vector3(0, destCharacter.eulerAngles.y, 0));
                targetChar = targetCharacter;

                Character.transform.localRotation = Quaternion.Slerp(Character.transform.localRotation, targetCharacter, 2 * Time.deltaTime);
            }
           
      
        }
        
        
        
        

        if (_lerped)
        {
            if (_dm.ended)
            {
                Cursor.lockState = CursorLockMode.Locked;
                //NextScene();
                //conversationState = false;
                //_dm.SetText();
                if(sceneFinished == true)
                {
                    //sceneFinished = false;
                    //LerpObjectToMousePoint();

                    StartCoroutine(TransitionFromScene());

                }
                if(sceneFinished == false)
                {
                    StartCoroutine(TransitionToScene());
                }
                //StartCoroutine(TransitionToScene());
                //LerpObjectToMousePoint();
                _lerped = false;
                //NextScene();
            }
            //Into = false;
            //_lerped = false;
        }

        if (back)
        {
            
            Character.transform.Translate(Vector3.back * 0.005f);
            

        }
    }
    // public void LerpObjectToMousePoint()
    // {
    //     StartCoroutine(LerpedToMouse(playerCamera.rotation, StartPos, 2f));
    // }

    private void FollowMouse()
    {
        back = true;
    }


    //This sets our mouse locked and unlocked
    private void ToggleMouseLockState(bool _toggle)
    {
        if (_toggle)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    [SerializeField]
    private Vector3 playerEnterStart;
    [SerializeField]
    private Quaternion playerEnterStartRotation;
    
    public Transform Character;
    
    
    public IEnumerator Lerped()
    {
        //back = true;
        AngleAxisFreeze = firstPerson.anglex;
        playerEnterStart = playerController.position;
        playerEnterStartRotation = playerController.rotation;

        //back = true;

        //yield return new WaitForSeconds(0.1f);
        conversationState = true;

        yield return new WaitForSeconds(0.1f);

        StartPos = playerCamera.rotation;

        yield return new WaitForSeconds(0.4f);

        FadeInObject();


        Into = true;


        yield return new WaitForSeconds(2f);
    
        Into = false; 
        //playerCamera.rotation = playerCamera.rotation;
        
        _lerped = true;
       
        yield return new WaitForEndOfFrame();

        Cursor.lockState = CursorLockMode.None;


        //mainCamera.rotation = dest;

        


        yield break;
       
    }


    IEnumerator TransitionToScene()
    {
        if(nextSceneString != "please Stop")
        {
                if (!sceneFinished)
            {
                FadeOutObjects();

                back = true;

                yield return new WaitForSeconds(2f);

                FadeOutObject();

                yield return new WaitForSeconds(3f);

                back = false;
            }


        }


        if(nextSceneString == "please Stop")
        {
            conversationState = false;
        }
        // if (!sceneFinished)
        // {
        //     FadeOutObjects();

        //     back = true;

        //     yield return new WaitForSeconds(2f);

        //     FadeOutObject();

        //     yield return new WaitForSeconds(3f);

        //     back = false;
        // }
        //FadeOutObjects();
        

        // back = true;

        // yield return new WaitForSeconds(2f);

        // FadeOutObject();

        // yield return new WaitForSeconds(3f);

        // back = false;
        
        //NextScene();
        NextScene();

        //yield return new WaitForSeconds(1f);

        if (sceneFinished)
        {
            //NextScene();
            FadeInObjects();
        }

        //_dm.ended = false;

        yield return new WaitForSeconds(3f);
        
        

        // if(_dm.ended)
        // {
        //     conversationState = false;
        // }

        yield break;
    }

    public IEnumerator TransitionFromScene()
    {
        //FadeOutObjects();

        //back = true;
        yield return new WaitForSeconds(1f);
        //conversationState = false;
        
        //yield return new WaitForSeconds(0.4f);
        NextScene();
        //back = false;
        yield return new WaitForSeconds(0.4f);
        //directionalLight.GetComponent<Light>().intensity = 0.001f;
        Cursor.lockState = CursorLockMode.Locked;
        FadeInObjects();

        //StayStill = true;

        yield return new WaitForSeconds(2f);

        //Cursor.lockState = CursorLockMode.Locked;
        nextSceneString = ("");
        conversationState = false;
        sceneFinished = false;
        yield break;
    }


    public float speed;

    public GameObject StupidCar;
    public GameObject wayPoint;
    public Vector3 wayPointPos;
    public float threshold = 0.05f;

    public float time;
    

    public IEnumerator CarCrash()
    {
        wayPoint = _gameHandler.carCam;
        yield return new WaitForSeconds(20f);
        //conversationState = false;
        
        //yield return new WaitForSeconds(0.4f);
        //NextScene();
        //back = false;

        //wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        float elapsedTime = 0;
        time = elapsedTime;

        Dialogue.SetActive(true);


        while (elapsedTime <= threshold)
        {   
            //StupidCar.transform.LookAt(wayPoint.transform);
            StupidCar.SetActive(true);
            wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
            
            StupidCar.transform.position = Vector3.MoveTowards(StupidCar.transform.position, wayPointPos, speed * elapsedTime);
            //StupidCar.transform.Translate(Vector3.forward, speed);

            yield return null;


            elapsedTime += Time.deltaTime;

        }

        yield return new WaitForEndOfFrame();

        Application.Quit();
        
        yield break;
    }



    // public GameObject cafeFade;
    // public GameObject swingFade;
    // public GameObject carFade;
    // public GameObject houseFade;

    
    public void NextScene()
    {
        if(nextSceneString != null)
        {
            if(nextSceneString == "cafe")
            {
                _gameHandler.cafe = true;
                directionalLight.GetComponent<Light>().intensity = 0.6f;
                RenderSettings.fogColor = new Color(0.706f, 0.616f, 0.8113f, 1f);
                RenderSettings.fogDensity = 0.04f;
            }
            if(nextSceneString == "car")
            {
                _gameHandler.car = true;
                directionalLight.GetComponent<Light>().intensity = 0.2f;
                RenderSettings.fogColor = new Color(0.177f, 0.2024f, 0.2452f, 1f);
                RenderSettings.fogDensity = 0.05f;
                StartCoroutine(CarCrash());
                conversationState = false;
            }
            if(nextSceneString == "intro")
            {
                _gameHandler.intro = true;
                directionalLight.GetComponent<Light>().intensity = 0.5f;
                FadeInObjects();
                RenderSettings.fogColor = new Color(0.19f, 0.05f, 0.07f, 1f);
                RenderSettings.fogDensity = 0.15f;
            }
            if(nextSceneString == "swing")
            {
                 _gameHandler.swing = true;
                directionalLight.GetComponent<Light>().intensity = 0.8f;
                RenderSettings.fogColor = new Color(0.706f, 0.616f, 0.8113f, 1f);
                RenderSettings.fogDensity = 0.04f;
                conversationState = false;
            }
            if(nextSceneString == "house")
            {
                _gameHandler.house = true;
                RenderSettings.fogColor = new Color(0.706f, 0.616f, 0.8113f, 1f);
                RenderSettings.fogDensity = 0.04f;
                directionalLight.GetComponent<Light>().intensity = 0.8f;
                conversationState = false;
            }

            
        
            //HandlerBool = true;
            
        }
        //_gameHandler.bool(nextSceneString) = true;
        //_gameHandler.nextSceneString = false;
    }

}
