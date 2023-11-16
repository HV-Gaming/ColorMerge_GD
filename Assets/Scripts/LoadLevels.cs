using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene(2);

    }
   
    public void Level2()
    {
        SceneManager.LoadScene(2);

    }
    public void Level3()
    {
        SceneManager.LoadScene(2);

    }
    public void Level4()
    {
        SceneManager.LoadScene(2);

    }
    public void Level5()
    {
        SceneManager.LoadScene(2);

    }
     public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Levelselect()
    {
        SceneManager.LoadScene(1);
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
    




}
