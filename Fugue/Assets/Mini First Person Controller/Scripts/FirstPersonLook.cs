using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    public DialogueManager dm;
    public Vector2 rawFrameVelocity;
    [SerializeField]
    public Vector2 mouseDelta;


    Vector2 velocity;
    Vector2 frameVelocity;
    public Transform parentRotate;

    public float anglex;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }


    void Awake()
    {
        
    }
    void Start()
    {
        dm = DialogueManager._instance;
        // Lock the mouse cursor to the gameCursor.lockState = CursorLockMode.Locked; screen.
        Cursor.lockState = CursorLockMode.Locked;

    }
    

    void Update()
    {

        //dm.playerCamera = parentRotate;

        //dm.mainCamera = gameObject.transform;
        dm.mainCamera = gameObject.transform;
        dm.playerCamera = parentRotate;
        dm.Character = character;


        if (!dm.conversationState)
        {
            
            mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            

            //parentRotate.rotation = gameObject.transform.rotation;
        }
        

        //mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);


        //frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        if (!dm.conversationState)
        {
            dm.playerCamera.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            //parentRotate.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }

        //character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        


        anglex = velocity.x;
        // Rotate camera up-down and controller left-right from velocity.

        if (dm.conversationState)
        { 
            
        }
      

    }
}
