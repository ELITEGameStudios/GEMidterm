using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public GameObject winText, loseText, inGameText, playerObject;
    public Transform startpos;

    bool isAlive;
    private void Awake() {

        if(Instance == null) {Instance = this;}
        else if(Instance != this){Destroy(this);}    
        
    }

    void Update()
    {
        if (!isAlive)
        {
            if(Input.GetKey(KeyCode.W)){ResetGame();}
        }   
    }

    public void EndGame(bool winCon = false)
    {
        isAlive = false;
        inGameText.SetActive(false);

        if(winCon) winText.SetActive(true);
        else loseText.SetActive(true);
    }


    public void ResetGame()
    {
        
        winText.SetActive(false);
        loseText.SetActive(false);
        playerObject.transform.position = startpos.position;
        
        StartGame();
    }
    
    public void StartGame()
    {
        isAlive = true;
        inGameText.SetActive(true);
    }


}
