using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){

        if(gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player"))){
            FindObjectOfType<Game_config>().addscore(20);
            Destroy(gameObject);
        }
    }
}
