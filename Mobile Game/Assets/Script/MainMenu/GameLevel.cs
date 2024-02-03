using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLevel : MonoBehaviour
{
    public Animator anim;
    public void PickLevel(int i)
    {

        SceneManager.LoadScene(i);
        // add transtion later 
    }
    public IEnumerator Wait(int i)
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        
        anim.SetTrigger("Start");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
