using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    public UnityEvent OnTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered.Invoke();
    }
}
