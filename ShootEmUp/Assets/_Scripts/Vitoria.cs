using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public void Winner()
    {
        SceneManager.LoadScene("Menu");
    }
}