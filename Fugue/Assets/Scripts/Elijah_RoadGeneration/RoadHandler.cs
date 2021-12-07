using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHandler : MonoBehaviour
{
    public float RoadSpeed;
    public bool canDestroy;
    private GameHandler _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameHandler._instance;
    }

    private void FixedUpdate() 
    {
       gameObject.transform.Translate(Vector3.forward * RoadSpeed); 
       if(canDestroy)
       {
           DestroyRoadChunk();
       }
    }

    public void DestroyRoadChunk()
    {
        Destroy(gameObject);
    }

    public void CanDestroyRoad()
    {
        //canDestroy = true;
        if(_gameManager.canClone)
        {
            _gameManager.CloneRoad();
            _gameManager.currentRoad = this;
            //_gameManager.previousRoad = this;
            
        }
        else
        {
            _gameManager.CreateRoadSection();
            _gameManager.currentRoad = this;
        }
        //_gameManager.CreateRoadSection();
        
       
    }
}
