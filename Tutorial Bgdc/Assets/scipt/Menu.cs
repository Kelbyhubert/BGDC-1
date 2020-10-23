using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void startlvl()
    {
        SceneManager.LoadScene(1);
    }
    public void menu()
    {
        FindObjectOfType<Game_config>().Destroy();
        SceneManager.LoadScene(0);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
