using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText1;
    public Text scoreText2;
    public GameObject field1GO;
    public GameObject field2GO;
    private Field field1;
    private Field field2;
    public GameObject gameOverObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        field1 = field1GO.GetComponent<Field>();
        field2 = field2GO.GetComponent<Field>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        int score1 = field1.GetScore();
        int score2 = field2.GetScore();

        if (score1 >= 100)
            WinnerPlayer(2);
        if (score2 >= 100)
            WinnerPlayer(1);
        
        scoreText1.text = field1.GetScore().ToString() + "%";
        scoreText2.text = field2.GetScore().ToString() + "%";
    }

    void WinnerPlayer(int winner)
    {
        Debug.Log("Winner Player " + winner);
        gameOverObject.SetActive(true);
            Time.timeScale = 0;
    }

    public void StartOver()
    {
        SceneManager.LoadScene(0);
    }
}
