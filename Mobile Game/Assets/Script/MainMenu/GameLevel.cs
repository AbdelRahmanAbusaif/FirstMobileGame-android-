using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLevel : MonoBehaviour
{
    public Animator anim;
    public void PickLevel(int sceneIndex) => SceneManager.LoadScene(sceneIndex);// add transtion later 
    public void Quit() => Application.Quit();

    //public IEnumerator Wait(int i)
    //{
    //    anim.SetTrigger("End");
    //    yield return new WaitForSeconds(1);

    //    anim.SetTrigger("Start");
    //}
}
