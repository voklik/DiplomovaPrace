using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    /**Tato t��da slou�� pro zm�n�n� aktu�ln� sc�ny a to bu� n�zvem sc�ny, 
    anebo ��slem sc�ny, kter� je ur�eno v samotn� aplikaci a nelze to m�nit.
    **/
    void Start()
    {
        Debug.Log("LoadSceneA");
    }

    public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }

    public void LoadB(int sceneANumber)
    {
        Debug.Log("sceneBuildIndex to load: " + sceneANumber);
        SceneManager.LoadScene(sceneANumber);
    }
}
