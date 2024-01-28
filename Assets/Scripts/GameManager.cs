using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float respawnDelay = 1.4f;
    private bool isGameEnd;
    private int score;
    public Text scoreText;
    public Text winText;
    public GameObject WinnerUI;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        if (isGameEnd==false)
        {
            isGameEnd = true;
            StartCoroutine("RespawnCoroutine"); 
        }
        
    }
  
    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return  new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       /* playerController.transform.position= playerController.respawnPoint;
        playerController.gameObject.SetActive(true); */
        isGameEnd=false;
    }
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }

    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "TEBRIKLER BROM";
        Invoke("NextLevel", respawnDelay * 2);
      
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("hey abim nie çalýþmýyon");
    }
}
