using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterAI : MonoBehaviour
{
    public GameObject[] hunters;
    public GameObject hare;
    public GameObject[] pos;
    public GameObject UI;
    public Text text;
    public Text steps;
    public Text turn;
    public GameObject Win;
    public GameObject Lose;
    public GameObject Turn;
    string difficulty;
    int stepNum;
    bool isClicked;
    bool isYourTurn;

    void Start(){
        stepNum = 0;
        steps.text = "Steps: " + stepNum;
        difficulty = text.text;
        isClicked = false;
        isYourTurn = false;
        UI.SetActive(false);
        Turn.SetActive(true);
        StartCoroutine(GameRunning());
    }

    IEnumerator GameRunning(){
        while(!IfFinished()){
            if(stepNum%2==0){
                turn.text = "AI is operating...";
                yield return new WaitForSeconds(2);
                yield return new WaitUntil(() => EagleMove());
                isYourTurn = true;
            } else{
                turn.text = "Your turn!";
                yield return new WaitUntil(() => isClicked);
                isClicked = false;
                isYourTurn = false;
            }
            stepNum++;
        }
    }

    bool EagleMove(){
        if(stepNum==0){
            hunters[2].GetComponent<EagleAttribute>().curPos = pos[4];
            hunters[2].transform.position = new Vector3(pos[4].transform.position.x, hunters[2].transform.position.y, pos[4].transform.position.z);
            return true;
        }else{
            return true;
        }
    }
    void Update(){
        if(isYourTurn && Input.GetMouseButton(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                int i=0;
                while(hare.GetComponent<HareAttribute>().psbDes[i] != null){
                    if (hit.collider.gameObject.name == hare.GetComponent<HareAttribute>().psbDes[i].name 
                    && hunters[0].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name
                    && hunters[1].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name
                    && hunters[2].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name)
                    {
                        hare.transform.position = new Vector3(hare.GetComponent<HareAttribute>().psbDes[i].transform.position.x, hare.transform.position.y, hare.GetComponent<HareAttribute>().psbDes[i].transform.position.z);
                        hare.GetComponent<HareAttribute>().curPos = hare.GetComponent<HareAttribute>().psbDes[i];
                        hare.GetComponent<HareAttribute>().psbDes = hare.GetComponent<HareAttribute>().curPos.GetComponent<HareAttribute>().psbDes;
                        isClicked = true;
                        break;
                    }
                    i++;
                }
            }
        }
    }

    bool IfFinished(){
        if(stepNum==51){
            Win.SetActive(true);
            return true;
        }
        if((hare.GetComponent<HareAttribute>().psbDes[0].transform.position==hunters[0].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[0].transform.position==hunters[1].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[0].transform.position==hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[1].transform.position==hunters[0].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[1].transform.position==hunters[1].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[1].transform.position==hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[2].transform.position==hunters[0].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[2].transform.position==hunters[1].GetComponent<EagleAttribute>().curPos.transform.position||hare.GetComponent<HareAttribute>().psbDes[2].transform.position==hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)){
            Lose.SetActive(true);
            return true;
        }
        if(hare.GetComponent<HareAttribute>().curPos.transform.position.x<=hunters[0].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x<=hunters[1].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x<=hunters[2].GetComponent<EagleAttribute>().curPos.transform.position.x){
            Win.SetActive(true);
            return true;
        }

        return false;
    }
}
