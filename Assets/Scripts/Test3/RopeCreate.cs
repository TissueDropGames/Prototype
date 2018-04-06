using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCreate : MonoBehaviour {

    GameObject goPlayer1;
    GameObject goPlayer2;
    public GameObject goLinkPrefab;
    public List<GameObject> agoLinks;

    float fDistanseBetweenPlayer;
    int iAmountOfNodes;
    float fRadius;


    // Use this for initialization
    void Start () {
        goPlayer1 = GameObject.Find("Player1");
        goPlayer2 = GameObject.Find("Player2");

        fDistanseBetweenPlayer = Vector3.Distance(goPlayer1.transform.position, goPlayer2.transform.position);

        fRadius = goLinkPrefab.GetComponent<CircleCollider2D>().radius;

        // calculates how many nodes is needed to get a rope
        iAmountOfNodes = (int)((fDistanseBetweenPlayer)/(fRadius + fRadius * 3.14));
        
        GenerateRope();
    }
	
    private void GenerateRope() {
       for (int i = 0; i < iAmountOfNodes; i++) {

            GameObject goLink = Instantiate(goLinkPrefab, transform);
            agoLinks.Add(goLink);
            Rigidbody2D rbRigid = goLink.GetComponent<Rigidbody2D>();
            HingeJoint2D hjJoint = goLink.GetComponent<HingeJoint2D>();

            if(i == 0) {
                hjJoint.connectedBody = goPlayer2.GetComponent<Rigidbody2D>();
                hjJoint.anchor = Vector3.zero;
                hjJoint.connectedAnchor = new Vector3(0, - 1, 0);
            }
            else{
                hjJoint.connectedBody = agoLinks[i - 1].GetComponent<Rigidbody2D>();
                    
                    //hjJoint.anchor = Vector3.zero;
                hjJoint.connectedAnchor = new Vector3(0.8f, 0, 0);
            }
       }
        goPlayer1.GetComponent<HingeJoint2D>().connectedBody = agoLinks[agoLinks.Count-1].GetComponent<Rigidbody2D>();
    }

    public int GetLinksLenght() {
        return agoLinks.Count;
    }
    public List<GameObject> GetLinkList() {
        return agoLinks;
    }

}
