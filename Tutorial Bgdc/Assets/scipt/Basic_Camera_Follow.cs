using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Camera_Follow : MonoBehaviour
{
    Player player;
    
    // Start is called before the first frame update
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(Playerpos.x, Playerpos.y, transform.position.z);
    }
}
