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
    int moveNum;

    void Start()
    {
        moveNum = 0;
        stepNum = 0;
        steps.text = "Steps: " + stepNum;
        difficulty = text.text;
        isClicked = false;
        isYourTurn = false;
        UI.SetActive(false);
        Turn.SetActive(true);
        StartCoroutine(GameRunning());
    }

    IEnumerator GameRunning()
    {
        while (!IfFinished())
        {
            if (stepNum % 2 == 0)
            {
                turn.text = "AI is operating...";
                yield return new WaitForSeconds(2);
                yield return new WaitUntil(() => EagleMove());
                isYourTurn = true;
            }
            else
            {
                turn.text = "Your turn!";
                yield return new WaitUntil(() => isClicked);
                isClicked = false;
                isYourTurn = false;
            }
            stepNum++;
        }
    }

    bool EagleMove()
    {
        switch (moveNum)
        {
            case 0:
                EagleMove0();
                break;
            case 1:
                EagleMove1();
                break;
            case 2:
                EagleMove2();
                break;
            case 3:
                EagleMove3();
                break;
            case 4:
                EagleMove4();
                break;
            case 5:
                EagleMove5();
                break;
            case 6:
                EagleMove6();
                break;
            case 7:
                EagleMove7();
                break;
        }
        return true;
    }

    void EagleMove0()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            hunters[2].GetComponent<EagleAttribute>().curPos = pos[4];
            hunters[2].GetComponent<EagleAttribute>().psbDes = pos[4].GetComponent<EagleAttribute>().psbDes;
            hunters[2].transform.position = new Vector3(pos[4].transform.position.x, hunters[2].transform.position.y, pos[4].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos8")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[10];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[10].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[10].transform.position.x, hunters[1].transform.position.y, pos[10].transform.position.z);
            moveNum = 6;
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos6")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[10];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[10].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[10].transform.position.x, hunters[1].transform.position.y, pos[10].transform.position.z);
            moveNum = 5;
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos9")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[10];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[10].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[10].transform.position.x, hunters[1].transform.position.y, pos[10].transform.position.z);
            moveNum = 6;
        }
    }
    void EagleMove1()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos4")
            {
                if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8" && hunters[2].GetComponent<EagleAttribute>().curPos.name == "Pos9")
                {
                    hunters[0].GetComponent<EagleAttribute>().curPos = pos[5];
                    hunters[0].GetComponent<EagleAttribute>().psbDes = pos[5].GetComponent<EagleAttribute>().psbDes;
                    hunters[0].transform.position = new Vector3(pos[5].transform.position.x, hunters[1].transform.position.y, pos[5].transform.position.z);
                }
                else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8")
                {
                    hunters[2].GetComponent<EagleAttribute>().curPos = pos[8];
                    hunters[2].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
                    hunters[2].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
                }
                else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos9")
                {
                    hunters[2].GetComponent<EagleAttribute>().curPos = pos[7];
                    hunters[2].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                    hunters[2].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
                }
            }
        }
        else if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos6")
        {
            if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8" && hunters[2].GetComponent<EagleAttribute>().curPos.name == "Pos9")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[4];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[4].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[4].transform.position.x, hunters[1].transform.position.y, pos[4].transform.position.z);
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[2];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[2].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[2].transform.position.x, hunters[1].transform.position.y, pos[2].transform.position.z);
                moveNum = 2;
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos9")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[1];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[1].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[1].transform.position.x, hunters[1].transform.position.y, pos[1].transform.position.z);
                moveNum = 2;
            }
        }
        else if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos11")
        {
            hunters[0].GetComponent<EagleAttribute>().curPos = pos[1];
            hunters[0].GetComponent<EagleAttribute>().psbDes = pos[1].GetComponent<EagleAttribute>().psbDes;
            hunters[0].transform.position = new Vector3(pos[1].transform.position.x, hunters[1].transform.position.y, pos[1].transform.position.z);
            moveNum = 2;
        }
        else if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos10")
        {
            hunters[0].GetComponent<EagleAttribute>().curPos = pos[2];
            hunters[0].GetComponent<EagleAttribute>().psbDes = pos[2].GetComponent<EagleAttribute>().psbDes;
            hunters[0].transform.position = new Vector3(pos[2].transform.position.x, hunters[1].transform.position.y, pos[2].transform.position.z);
            moveNum = 2;
        }
    }
    void EagleMove2()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8" && hunters[2].GetComponent<EagleAttribute>().curPos.name == "Pos9")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[5];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[5].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[5].transform.position.x, hunters[1].transform.position.y, pos[5].transform.position.z);
            }
            else if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos2" || hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos11")
            {
                hunters[2].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[2].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[2].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
            }
            else if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos3" || hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos10")
            {
                hunters[2].GetComponent<EagleAttribute>().curPos = pos[8];
                hunters[2].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
                hunters[2].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
            }
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos6")
        {
            if (hunters[2].GetComponent<EagleAttribute>().curPos.name == "Pos5")
            {
                if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8")
                {
                    hunters[0].GetComponent<EagleAttribute>().curPos = pos[8];
                    hunters[0].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
                    hunters[0].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
                }
                else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos9")
                {
                    hunters[0].GetComponent<EagleAttribute>().curPos = pos[7];
                    hunters[0].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                    hunters[0].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
                }
            }
            else
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[4];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[4].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[4].transform.position.x, hunters[1].transform.position.y, pos[4].transform.position.z);
            }
        }
    }
    void EagleMove3()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos9")
        {
            if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos3")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[9];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[9].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[9].transform.position.x, hunters[0].transform.position.y, pos[9].transform.position.z);
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8")
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[5];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[5].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[5].transform.position.x, hunters[1].transform.position.y, pos[5].transform.position.z);
            }
            else
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[0].transform.position.y, pos[7].transform.position.z);
            }
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos11" && hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos10")
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[0].transform.position.y, pos[7].transform.position.z);
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8" && hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos9")
            {
                hunters[2].GetComponent<EagleAttribute>().curPos = pos[5];
                hunters[2].GetComponent<EagleAttribute>().psbDes = pos[5].GetComponent<EagleAttribute>().psbDes;
                hunters[2].transform.position = new Vector3(pos[5].transform.position.x, hunters[1].transform.position.y, pos[5].transform.position.z);
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos6")
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
            }
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos6")
        {
            if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos11" && hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos10")
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[0].transform.position.y, pos[7].transform.position.z);
            }
            else if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos8")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[8];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
            }
        }
    }
    void EagleMove4()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            hunters[0].GetComponent<EagleAttribute>().curPos = pos[3];
            hunters[0].GetComponent<EagleAttribute>().psbDes = pos[3].GetComponent<EagleAttribute>().psbDes;
            hunters[0].transform.position = new Vector3(pos[3].transform.position.x, hunters[1].transform.position.y, pos[3].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos11")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos10")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[8];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos8")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[8];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[8].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[8].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
            moveNum = 1;
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos9")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[8].transform.position.z);
            moveNum = 1;
        }
    }
    void EagleMove5()
    {

    }
        void EagleMove6()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos6")
        {
            if (hunters[1].GetComponent<EagleAttribute>().curPos.name == "Pos11")
            {
                hunters[1].GetComponent<EagleAttribute>().curPos = pos[7];
                hunters[1].GetComponent<EagleAttribute>().psbDes = pos[7].GetComponent<EagleAttribute>().psbDes;
                hunters[1].transform.position = new Vector3(pos[7].transform.position.x, hunters[1].transform.position.y, pos[7].transform.position.z);
                moveNum = 7;
            }
            else
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[2];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[2].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[2].transform.position.x, hunters[0].transform.position.y, pos[2].transform.position.z);
                moveNum = 2;
            }
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos9")
        {
            hunters[0].GetComponent<EagleAttribute>().curPos = pos[3];
            hunters[0].GetComponent<EagleAttribute>().psbDes = pos[3].GetComponent<EagleAttribute>().psbDes;
            hunters[0].transform.position = new Vector3(pos[3].transform.position.x, hunters[0].transform.position.y, pos[3].transform.position.z);
            moveNum = 1;
        }
    }
    void EagleMove7()
    {
        if (hare.GetComponent<HareAttribute>().curPos.name == "Pos9")
        {
            if (hunters[0].GetComponent<EagleAttribute>().curPos.name == "Pos8")
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[3];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[3].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[3].transform.position.x, hunters[1].transform.position.y, pos[3].transform.position.z);
                moveNum = 1;
            }
            else
            {
                hunters[0].GetComponent<EagleAttribute>().curPos = pos[2];
                hunters[0].GetComponent<EagleAttribute>().psbDes = pos[2].GetComponent<EagleAttribute>().psbDes;
                hunters[0].transform.position = new Vector3(pos[2].transform.position.x, hunters[1].transform.position.y, pos[2].transform.position.z);
                moveNum = 4;
            }
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos7")
        {
            hunters[1].GetComponent<EagleAttribute>().curPos = pos[5];
            hunters[1].GetComponent<EagleAttribute>().psbDes = pos[5].GetComponent<EagleAttribute>().psbDes;
            hunters[1].transform.position = new Vector3(pos[5].transform.position.x, hunters[1].transform.position.y, pos[5].transform.position.z);
        }
        else if (hare.GetComponent<HareAttribute>().curPos.name == "Pos8")
        {
            hunters[0].GetComponent<EagleAttribute>().curPos = pos[1];
            hunters[0].GetComponent<EagleAttribute>().psbDes = pos[1].GetComponent<EagleAttribute>().psbDes;
            hunters[0].transform.position = new Vector3(pos[1].transform.position.x, hunters[1].transform.position.y, pos[1].transform.position.z);
            moveNum = 4;
        }
    }
    void Update()
    {
        if (isYourTurn && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                int i = 0;
                while (hare.GetComponent<HareAttribute>().psbDes[i] != null)
                {
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

    bool IfFinished()
    {
        if (stepNum == 51)
        {
            Win.SetActive(true);
            return true;
        }
        if ((hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[0].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[1].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position)
        && (hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[0].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[1].GetComponent<EagleAttribute>().curPos.transform.position || hare.GetComponent<HareAttribute>().psbDes[2].transform.position == hunters[2].GetComponent<EagleAttribute>().curPos.transform.position))
        {
            Lose.SetActive(true);
            return true;
        }
        if (hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[0].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[1].GetComponent<EagleAttribute>().curPos.transform.position.x
        && hare.GetComponent<HareAttribute>().curPos.transform.position.x <= hunters[2].GetComponent<EagleAttribute>().curPos.transform.position.x)
        {
            Win.SetActive(true);
            return true;
        }

        return false;
    }
}