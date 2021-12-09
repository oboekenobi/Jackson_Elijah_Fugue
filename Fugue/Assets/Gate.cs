using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public DialogueManager _dm;
    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _dm = DialogueManager._instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(_dm.openGate == true)
        {
            _anim.SetBool("Open", true);
        }

    }
}
