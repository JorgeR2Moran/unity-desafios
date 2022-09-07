using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void OnClickPlay(){
        Debug.Log("SE PRESIONO EL BOTÓN");
        SceneManager.LoadScene("TDA");
    }
}
