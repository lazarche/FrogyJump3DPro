using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject text, btnCon, btnRest;

    float time = 0;
    bool active = false, started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartTimer() {
        active = true;
    }

    public void LoseGame() {
        btnRest.SetActive(true);
        active = false;
    }

    public void WinGame() {
        btnCon.SetActive(true);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started && Input.GetMouseButtonUp(0)) {
            started = true;
            StartTimer();
        }


        if(active) {
            time += Time.deltaTime;
            text.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + Mathf.Round(time);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene() {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCount > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        } else 
            SceneManager.LoadScene(0);
    }
}
