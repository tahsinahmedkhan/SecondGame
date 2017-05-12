using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public CharacterController MyController;
    public Transform Cameratransform;
    public float GravityStrength = 5f;
    public float jumpspeed = 10f;
    public float speed = 3f;
    float verticalvelocity;
    bool canjump = false;
	
	// Update is called once per frame
	void Update () {
        Vector3 myvector = new Vector3(0, 0, 0);
        myvector.x = Input.GetAxis("Horizontal");
        myvector.z = Input.GetAxis("Vertical");
        myvector = Vector3.ClampMagnitude(myvector, 1f);
        //myvector.y = 9001;
        myvector = myvector * speed*Time.deltaTime;
        Quaternion inputRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(Cameratransform.forward, Vector3.up),Vector3.up);
        myvector = inputRotation * myvector;
        verticalvelocity = verticalvelocity-GravityStrength*Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {

            if(canjump)
            verticalvelocity = verticalvelocity + jumpspeed;
        }
        myvector.y = verticalvelocity*Time.deltaTime;
        CollisionFlags flags = MyController.Move(myvector);

        if ((flags & CollisionFlags.Sides | CollisionFlags.Below) != 0)
        {
            canjump = true;
            verticalvelocity = -3f;
        }
        else
            canjump = false;
    }
}
