using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Application.targetFrameRate = 60;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("NEXT SCENE" + nextSceneIndex);
        Debug.Log("SCENE COUNT: " + SceneManager.sceneCountInBuildSettings);
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
