using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDeJogo : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
