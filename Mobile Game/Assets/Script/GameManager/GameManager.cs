using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int Counter = 0;
    public Animator anim;
    private void Awake()
    {
        LoadCounter();
        if(Counter != Counter + 1)
        SaveCounter();
    }
    private void Start()
    {
        ForUIEnemy.count = 0;
        print($"Count : {Counter}");
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    private void Update()
    {
        if(ForUIEnemy.count==4)
        {
            SaveCounter();
            Physics2D.IgnoreLayerCollision(8, 9, true);
            StartCoroutine(Wait());

            ForUIEnemy.count = 0;
        }
        else
        {
            return;
        }
    }
    IEnumerator Wait()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        anim.SetTrigger("Start");
    }
    private void SaveCounter()
    {
        PlayerPrefs.SetInt("Counter", Counter);
        PlayerPrefs.Save();
    }

    private void LoadCounter()
    {
        if (PlayerPrefs.HasKey("Counter"))
        {
            if(Counter < 6)
            {
                Counter = PlayerPrefs.GetInt("Counter");
            }
            else
            {
                PlayerPrefs.SetInt("Counter", Counter);
                PlayerPrefs.Save();
            }
        }
    }
    public void PauseMenu() => Time.timeScale = 0;
    public void ResumeMenu() => Time.timeScale = 1;
    public void MainMenu() => SceneManager.LoadScene("MainMenu");
}
