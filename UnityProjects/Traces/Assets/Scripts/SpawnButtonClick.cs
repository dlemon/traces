using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButtonClick : MonoBehaviour {

    private bool _instantiated = false;
    
    public void onClick()
    {
        if (!_instantiated)
        {
            _instantiated = true;

            GameObject cube = (GameObject)Resources.Load("PreFabs/Cube", typeof(GameObject));
            Vector3 spawnPos = new Vector3(0, 0, 30);

            Instantiate(cube, spawnPos, Quaternion.identity);
        }
    }
}
