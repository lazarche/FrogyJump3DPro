using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambuPlatformScript : MonoBehaviour
{
    BoxCollider2D col;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        col = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < player.transform.position.y)
            col.enabled = true;
            else
            col.enabled = false;

        if(player.GetComponent<PlayerController>().pass)
            col.enabled = false;
    }
}
