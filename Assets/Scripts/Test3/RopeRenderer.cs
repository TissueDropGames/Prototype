using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour {

    RopeCreate xCreateRope;
    LineRenderer lrLineRender;
    GameObject goPlayer1;
    GameObject goPlayer2;
    List<GameObject> agoRopeNodes;
    public int iVertexCount;
    // Use this for initialization
    void Start () {
        goPlayer1 = GameObject.Find("Player1");
        goPlayer2 = GameObject.Find("Player2");
        xCreateRope = gameObject.GetComponent<RopeCreate>();
        agoRopeNodes = xCreateRope.GetLinkList();
        lrLineRender = gameObject.GetComponent<LineRenderer>();
       // iVertexCount = xCreateRope.GetLinksLenght();
    }
	
	// Update is called once per frame
	void Update () {
        iVertexCount = xCreateRope.GetLinksLenght()+1;
        RenderLine();
	}

    void RenderLine(){

       lrLineRender.positionCount = iVertexCount; 

        int i = 0;

        lrLineRender.SetPosition(i, goPlayer2.transform.position);

        for (i = 1; i < agoRopeNodes.Count; i++){

            lrLineRender.SetPosition(i, agoRopeNodes[i-1].transform.position);

        }

        lrLineRender.SetPosition(i, goPlayer1.transform.position);

    }

}
