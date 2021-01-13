using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneShift : MonoBehaviour
{
    public void toEasy()
    {
        SceneManager.LoadScene(2);
    }
    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
