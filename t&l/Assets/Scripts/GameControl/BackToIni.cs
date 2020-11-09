using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToIni : MonoBehaviour
{
    public void Back2Ini(){
        SceneManager.LoadScene("InitialUI");
    }
}
