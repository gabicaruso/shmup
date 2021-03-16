using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Vidas : MonoBehaviour
{
   Text textComp;
   public PlayerController pc;
   void Start()
   {
       textComp = GetComponent<Text>();
   }
   
   void Update()
   {
       Debug.Log(pc.lifes);
       textComp.text = $"VIDAS: {pc.lifes}";
   }
}