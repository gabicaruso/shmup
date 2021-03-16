using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    private void OnCollisonEnter2D (Collision2D collider){
        if (collider.gameObject.tag == "Player"){
            SceneManager.LoadScene("Vitoria");
        }
    }
}
