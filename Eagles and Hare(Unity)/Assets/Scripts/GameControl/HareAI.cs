using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HareAI : MonoBehaviour
{
    public GameObject[] hunters;
    public Light[] lights;
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
    GameObject movedGO;

    void Start()
    {
        stepNum = 0;
        steps.text = "Steps: " + stepNum;
        difficulty = text.text;
        isClicked = false;
        isYourTurn = true;
        UI.SetActive(false);
        Turn.SetActive(true);
        if(difficulty == "Baby"){
            StartCoroutine(EasyGameRunning());
        }
        else if(difficulty == "Nightmare"){
            StartCoroutine(HardGameRunning());
        }
        else if (difficulty == "Random"){
            float ranNum;
            ranNum = Random.Range(0.0f, 2.0f);
            if(ranNum>=0&&ranNum<1){
                StartCoroutine(EasyGameRunning());
            }else{
                StartCoroutine(HardGameRunning());
            }
        }
    }

    IEnumerator EasyGameRunning(){
        while (!IfFinished())
        {
            if (stepNum % 2 == 1)
            {
                turn.text = "AI is operating...";
                yield return new WaitForSeconds(2);
                yield return new WaitUntil(() => RanHareMove());
                isYourTurn = true;
            }
            else
            {
                for (int i=0;i<3;i++){
                    lights[i].GetComponent<Light>().enabled = true;
                }
                movedGO = null;
                turn.text = "Your turn!";
                yield return new WaitUntil(() => isClicked);
                isClicked = false;
                isYourTurn = false;
                for (int i=0;i<3;i++){
                    lights[i].GetComponent<Light>().enabled = false;
                }
            }
            stepNum++;
            steps.text = "Steps: " + stepNum.ToString();
        }
    }
    
    IEnumerator HardGameRunning(){
        while (!IfFinished())
        {
            if (stepNum % 2 == 1)
            {
                turn.text = "AI is operating...";
                yield return new WaitForSeconds(2);
                yield return new WaitUntil(() => HareMove());
                isYourTurn = true;
            }
            else
            {
                for (int i=0;i<3;i++){
                    lights[i].GetComponent<Light>().enabled = true;
                }
                turn.text = "Your turn!";
                yield return new WaitUntil(() => isClicked);
                isClicked = false;
                isYourTurn = false;
                for (int i=0;i<3;i++){
                    lights[i].GetComponent<Light>().enabled = false;
                }
            }
            stepNum++;
            steps.text = "Steps: " + stepNum.ToString();
        }
    }

    bool RanHareMove(){
        int i = 0;
        List<int> psbPos = new List<int>();
        while(i<=7 && hare.GetComponent<HareAttribute>().psbDes[i]!=null){
            if(hare.GetComponent<HareAttribute>().psbDes[i].name!=hunters[0].GetComponent<EagleAttribute>().curPos.name&&hare.GetComponent<HareAttribute>().psbDes[i].name!=hunters[1].GetComponent<EagleAttribute>().curPos.name&&hare.GetComponent<HareAttribute>().psbDes[i].name!=hunters[2].GetComponent<EagleAttribute>().curPos.name){
                psbPos.Add(i);
            }
            i++;
        }
        float size = (float)psbPos.Count;
        float ranNum = Random.Range(0.0f, size);
        while(--size >= 0){
            if(ranNum>=size&&ranNum<size+1){
                GameObject tmp = hare.GetComponent<HareAttribute>().psbDes[psbPos[(int)size]];
                hare.GetComponent<HareAttribute>().curPos = tmp;
                hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                break;
            }
        }
        return true;
    }

    bool HareMove(){
        int i = 0;
        Queue<GameObject> des = new Queue<GameObject>();
        GameObject tmp;
        for (i = 0; i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if (tmp.transform.position.x <= hunters[0].GetComponent<EagleAttribute>().curPos.transform.position.x
            && tmp.transform.position.x <= hunters[1].GetComponent<EagleAttribute>().curPos.transform.position.x
            && tmp.transform.position.x <= hunters[2].GetComponent<EagleAttribute>().curPos.transform.position.x && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                hare.GetComponent<HareAttribute>().curPos = tmp;
                hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                return true;
            }
        }
            for (i = 0;  i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if ((tmp.name == "Pos1" || tmp.name == "Pos2" || tmp.name == "Pos3" || tmp.name == "Pos5") && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                hare.GetComponent<HareAttribute>().curPos = tmp;
                hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                return true;
            }
        }
        for (i = 0; i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if(tmp.name == "Pos4" && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                hare.GetComponent<HareAttribute>().curPos = tmp;
                hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                return true;
            }
        }
        for (i = 0; i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if (tmp.name == "Pos8" && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                if ("Pos2" == hunters[0].GetComponent<EagleAttribute>().curPos.name || "Pos2" == hunters[1].GetComponent<EagleAttribute>().curPos.name || "Pos2" == hunters[2].GetComponent<EagleAttribute>().curPos.name)
                {
                    des.Enqueue(tmp);
                }
                else
                {
                    hare.GetComponent<HareAttribute>().curPos = tmp;
                    hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                    hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                    return true;
                }
            }
        }
        for (i = 0; i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if (tmp.name == "Pos9" && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                if ("Pos3" == hunters[0].GetComponent<EagleAttribute>().curPos.name || "Pos3" == hunters[1].GetComponent<EagleAttribute>().curPos.name || "Pos3" == hunters[2].GetComponent<EagleAttribute>().curPos.name)
                {
                    des.Enqueue(tmp);
                }
                else
                {
                    hare.GetComponent<HareAttribute>().curPos = tmp;
                    hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
                    hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
                    return true;
                }
            }
        }
        for (i = 0; i <= 7 && hare.GetComponent<HareAttribute>().psbDes[i] != null; i++)
        {
            tmp = hare.GetComponent<HareAttribute>().psbDes[i];
            if (tmp.name == "Pos7" && tmp.name != hunters[0].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[1].GetComponent<EagleAttribute>().curPos.name && tmp.name != hunters[2].GetComponent<EagleAttribute>().curPos.name)
            {
                des.Enqueue(tmp);
            }
        }
        if (des.Count == 0)
        {
            return RanHareMove();
        } else
        {
            tmp = des.Dequeue();
            hare.GetComponent<HareAttribute>().curPos = tmp;
            hare.GetComponent<HareAttribute>().psbDes = tmp.GetComponent<HareAttribute>().psbDes;
            hare.transform.position = new Vector3(tmp.transform.position.x, hare.transform.position.y, tmp.transform.position.z);
            return true;
        }
        
    }
    
    void Update()
    {
        if (isYourTurn && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name.Contains("Eagle"))
            {
                for(int i=0;i<3;i++){
                    if(hit.collider.gameObject.name == hunters[i].name){
                        lights[i].GetComponent<Light>().enabled = true;
                        lights[(i+1)%3].GetComponent<Light>().enabled = false;
                        lights[(i+2)%3].GetComponent<Light>().enabled = false;
                        movedGO = hunters[i];
                    }
                }
            } else if (movedGO != null && Physics.Raycast(ray, out hit) && hit.collider.gameObject.name.Contains("Pos"))
            {
                int i=0;
                if(hunters[0].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name && hunters[1].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name && hunters[2].GetComponent<EagleAttribute>().curPos.name != hit.collider.gameObject.name && hare.GetComponent<HareAttribute>().curPos.name != hit.collider.gameObject.name)
                while(movedGO.GetComponent<EagleAttribute>().psbDes[i]!=null){
                    if(movedGO.GetComponent<EagleAttribute>().psbDes[i].name == hit.collider.gameObject.name){
                        movedGO.GetComponent<EagleAttribute>().curPos = hit.collider.gameObject;
                        movedGO.GetComponent<EagleAttribute>().psbDes = hit.collider.gameObject.GetComponent<EagleAttribute>().psbDes;
                        movedGO.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, hunters[2].transform.position.y, hit.collider.gameObject.transform.position.z);
                        isClicked = true;
                        break;
                    }
                    i++;
                }
            }
        }
    }

    bool IfFinished()
    {
        if (stepNum == 31)
        {
            Lose.SetActive(true);
            return true;
        }
        if ((hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position))
        {
            Win.SetActive(true);
            return true;
        }
        if (hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[0].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[1].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[2].GetComponent<EagleAttribute>().curPos.transform.position.x)
        {
            Lose.SetActive(true);
            return true;
        }

        return false;
    }
}
