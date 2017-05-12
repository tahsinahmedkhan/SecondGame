using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        print(name + "has been collected!");
    }
}
