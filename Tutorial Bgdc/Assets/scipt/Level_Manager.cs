using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] float Delay = 2f;
    // Start is called before the first frame update



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("touch");
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Debug.Log("Enter");
            StartCoroutine(LoadScene());
        }
        
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(Delay);

        var nextscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextscene + 1);

    }
}
