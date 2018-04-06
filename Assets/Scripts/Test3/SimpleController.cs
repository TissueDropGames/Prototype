using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour {

    public float thrust;
    Rigidbody2D rbRigid;

    public string sDir;
    public string sStuck;
    public string sLevitation;

    void Start () {
        rbRigid = gameObject.GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        if (Input.GetKey(sDir)) {
            if (sDir == "right") { 
                rbRigid.AddForce(Vector2.right * thrust);
            }
            else{
                rbRigid.AddForce(Vector2.left * thrust);
            }
        }
        if (Input.GetKey(sStuck)) {
            rbRigid.bodyType = RigidbodyType2D.Static;
        }
        else {
            rbRigid.bodyType = RigidbodyType2D.Dynamic;
        }
        if (Input.GetKey(sLevitation)) {
            rbRigid.AddForce(Vector2.up * thrust);
        }
    }
}
