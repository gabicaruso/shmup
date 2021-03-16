using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour
{
   Text textComp;
   public int score = 0;
   void Start()
   {
       textComp = GetComponent<Text>();
   }
   
   void Update()
   {
       textComp.text = $"PONTOS: {score}";
   }
}