using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    [SerializeField] private Text lastEnemyName;
    [SerializeField] private Image lastEnemyImage;
    [SerializeField] private Sprite[] lastEnemyIcon;

    [SerializeField] private Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedText(string newText){
        lastEnemyName.text = newText;
        SetLastEnemyIcon(newText);
    }

    public void SetLastEnemyIcon(string newText){
        switch(newText){
            case "FireTruck":
                lastEnemyImage.sprite = lastEnemyIcon[0];
                break;
            case "RaceCar":
                lastEnemyImage.sprite = lastEnemyIcon[1];
                break;
            case "SUV":
                lastEnemyImage.sprite = lastEnemyIcon[2];
                break;
        }
    }

    public void SetScoreText(){
        scoreText.text = GameManager.Score.ToString();
    }
}
