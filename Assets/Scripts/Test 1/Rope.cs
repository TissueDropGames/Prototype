using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Rigidbody hook;

    public GameObject linkPrefab;

    public Weight weigth;

    public int links = 7;

    public List<GameObject> agoLinks;

    private LineRenderer lrLine;
    private int iVertexCount = 2;

    void Start () {
        lrLine = GetComponent<LineRenderer>();
        GenerateRope();
    }


    void RenderLine()
    {

        lrLine.SetVertexCount(iVertexCount);

        int i;
        for (i = 0; i < agoLinks.Count; i++)
        {

            lrLine.SetPosition(i, agoLinks[i].transform.position);

        }

        lrLine.SetPosition(i, weigth.transform.position);

    }

    void GenerateRope()
    {
        Rigidbody previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            agoLinks.Add(link);
            HingeJoint joint = link.GetComponent<HingeJoint>();
            joint.connectedBody = previousRB;

            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody>();
            }
            else
            {
                weigth.ConnectRopeEnd(link.GetComponent<Rigidbody>());
            }


        }
    }

}
