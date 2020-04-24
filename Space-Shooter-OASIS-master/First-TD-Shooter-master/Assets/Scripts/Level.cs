using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    // Start is called before the first frame update
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
        
    }
    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
    IEnumerator WaitAndLoadWin()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Victory");
    }

    public void LoadVictory()
    {
        StartCoroutine(WaitAndLoadWin());
    }
}
