using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("NoticeScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("OverWorldUIScene", LoadSceneMode.Additive);
    }
}
