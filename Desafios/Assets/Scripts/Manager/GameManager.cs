using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const int V = 100;
    private static bool hitCar;
    public static bool HitCar { get => hitCar; set => hitCar = value; }

    private static bool hitWall;
    public static bool HitWall { get => hitWall; set => hitWall = value; }

    private static int score = 100;
    public static int Score {
        get => score; 
        set{
            score = value; 
            HUDManager.instance.SetScoreText();
        }
    }

    private static string lastEnemy = "";
    public static string LastEnemy { get => lastEnemy; set => lastEnemy = value; }

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            hitWall = false;
            hitCar = false;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
}
