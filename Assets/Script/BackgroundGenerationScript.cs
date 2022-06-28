using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerationScript : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(start, new Vector3(0,0,0), Quaternion.identity );
        for(float i = 11.8f; i < 200; i+= 7.9f) {
            Instantiate(walls[Random.Range(0,walls.Length)], new Vector3(0,i,0), Quaternion.Euler(0,180,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
