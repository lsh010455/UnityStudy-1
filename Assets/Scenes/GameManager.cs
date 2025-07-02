using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float time;
    private bool isGameOver;

    public GameObject GameOverText;
    public Text TimeText;
    public Text BestTimeText;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        isGameOver = false;
        GameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            time += Time.deltaTime;
            TimeText.text = "Time: " + time;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    public void EndGame()
    {
        isGameOver = true;
        GameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        if(!PlayerPrefs.HasKey("BestTime")) { bestTime = 0f; }
        else { bestTime = PlayerPrefs.GetFloat("BestTime");  }

        if (time > bestTime)
        {
            bestTime = time;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        BestTimeText.text = "Best Time: " + bestTime;
    }
}
