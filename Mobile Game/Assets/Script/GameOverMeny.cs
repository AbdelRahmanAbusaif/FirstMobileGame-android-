using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMeny : MonoBehaviour
{
    public GameObject GameOver;
    public Animator anim;
    public void GameOverActive()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
    public void GameOverDisActive()
    {
        Time.timeScale = 1;
        GameOver.SetActive(false);
        StartCoroutine(WaitAnimation());
        ForUIEnemy.count = 0;
    }
    public void Quit()
    {
        Application.Quit();
        print("Quitting");
    }
    public IEnumerator WaitAnimation()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        anim.SetTrigger("Start");
    }
}
