using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCreate : MonoBehaviour {

    GameObject goPlayer1;
    GameObject goPlayer2;

    public GameObject goLinkPrefab;

    public List<GameObject> agoLinks;

    float fDistanseBetweenPlayer;
    public int iAmountOfNodes;
    float fRadius;


    // Use this for initialization
    void Start () {
        goPlayer1 = GameObject.Find("Player1");
        goPlayer2 = GameObject.Find("Player2");

        fDistanseBetweenPlayer = Vector3.Distance(goPlayer1.transform.position, goPlayer2.transform.position);

        fRadius = goLinkPrefab.GetComponent<SphereCollider>().radius;

        // calculates how many nodes is needed to get a rope
        iAmountOfNodes = (int)((fDistanseBetweenPlayer)/(fRadius + fRadius * 3.14));

        GenerateRope();
    }
	
    private void GenerateRope() {
       for (int i = 0; i < iAmountOfNodes; i++) {

            GameObject link = Instantiate(goLinkPrefab, transform);
            agoLinks.Add(link);
            Rigidbody rbRigid = link.GetComponent<Rigidbody>();
            HingeJoint hjJoint = link.GetComponent<HingeJoint>();

            if(i <= iAmountOfNodes) {
                if(i == 0) {
                    hjJoint.connectedBody = goPlayer2.GetComponent<Rigidbody>();
                    hjJoint.anchor = Vector3.zero;
                    hjJoint.connectedAnchor = new Vector3(1, - 1, 0);
                }
                else{
                    hjJoint.connectedBody = agoLinks[i - 1].GetComponent<Rigidbody>();
                    
                    //hjJoint.anchor = Vector3.zero;
                    hjJoint.connectedAnchor = new Vector3(1.3f, 0, 0);
                }
            }
            else {
                
                goPlayer1.GetComponent<HingeJoint>().connectedBody = rbRigid;
            }

        }
    }

    public int GetLinksLenght() {
        return agoLinks.Count;
    }
}
