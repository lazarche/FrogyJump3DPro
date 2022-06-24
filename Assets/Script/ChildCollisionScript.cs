using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionScript : MonoBehaviour
{
    GameObject collision = null;

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag.Equals("Wall"))
            collision = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
       if(col.gameObject.tag.Equals("Wall"))
            collision = null;
    }

    public GameObject getCollision() {
        return collision;
    }
}
