using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Lvl1");
    }
}
