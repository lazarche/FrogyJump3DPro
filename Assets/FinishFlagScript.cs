using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlagScript : MonoBehaviour
{
    bool win = false;
    public GameObject[] confeti;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag.Equals("Player") && !win) {
            win = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().WinGame();
            foreach (GameObject go in confeti)
            {
                go.SetActive(true);                
            }
        }
    }
}
