using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HunterAI : MonoBehaviour
{
    public GameObject[] hunters;
    public GameObject piggy;
    public GameObject[] pos;
    public GameObject UI;
    public Text text;
    public Text steps;
    string difficulty;
    int stepNum;

    void Start(){
        stepNum = 0;
        steps.text = "Steps: " + stepNum;
        difficulty = text.text;
        UI.SetActive(false);
        StartCoroutine(GameRunning());
    }

    IEnumerator GameRunning(){
        while(!IfFinished()){
            yield return new WaitForSeconds(2);
            if(stepNum%2==0){
                EagleMove();
            } else{
                HareMove();
            }
            stepNum++;
        }
    }

    void EagleMove(){

    }

    void HareMove(){

    }

    bool IfFinished(){
        return false;
    }
}
