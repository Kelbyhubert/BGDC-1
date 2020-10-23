using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField] Text live;
    [SerializeField] Text score;
    Game_config game_Config;
    // Start is called before the first frame update
    void Start()
    {
        
        game_Config = FindObjectOfType<Game_config>();
    }

    // Update is called once per frame
    void Update()
    {
        live.text = game_Config.getlive().ToString();
        score.text = game_Config.getscore().ToString();
    }
}
