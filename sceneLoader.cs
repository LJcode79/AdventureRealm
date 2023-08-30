using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LeaveScene()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
