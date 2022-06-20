using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollisionScript : MonoBehaviour
{
    bool collision = false;

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag.Equals("Wall"))
        collision = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
       if(col.gameObject.tag.Equals("Wall"))
        collision = false;
    }

    public bool getCollision() {
        return collision;
    }
}
