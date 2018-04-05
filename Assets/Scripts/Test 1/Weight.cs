using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {
    public float distanceFromChainEnd = 0.6f;

    public void ConnectRopeEnd(Rigidbody endRB)
    {
        HingeJoint joint = gameObject.AddComponent<HingeJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
    }

}
