using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_config : MonoBehaviour
{
    [SerializeField] int gamelive = 3;
    [SerializeField] int gamescore;
    
    // Start is called before the first frame update
    void Awake(){
        int countgamesesion = FindObjectsOfType<Game_config>().Length;
        if( countgamesesion > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void addscore(int score){
        gamescore += score;
    }
    public int getlive(){
        return gamelive;
    }

    public int getscore(){
        return gamescore;
    }

    #region life
    public void GameLife(){
        if(gamelive > 1){
            takelife();
        }else{
            resetgame();
        }
    }
    void takelife(){
        gamelive--;
        var currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void resetgame(){
        SceneManager.LoadScene("Game Over");
    }

    public void Destroy(){
        Destroy(gameObject);

    }
    #endregion
}
