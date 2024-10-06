using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    public void ActivatePanel()
    {
        panel.SetActive(true);
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void DeactivatePanel()
    {
        panel.SetActive(false);
    }
}
