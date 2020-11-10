using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStart : MonoBehaviour
{
    public Text role;
    public GameObject game;
    public void StartGame(){
        if(role.text == "Eagles"){
            game.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<HunterAI>().enabled = true;
        }
        else if(role.text == "Hare"){
            game.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<HareAI>().enabled = true;
        }
    }
}
