using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float scale = 5f;
    public float life = 3f;
    public float damageInflicted = 0.5f;
    public float healing = 1f;
    public float velocity = 2f;
    public Vector3 direction = Vector3.forward;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale *= scale;
    }

    // Update is called once per frame
    void Update()
    {
        Damage(damageInflicted);
        Recovery(healing);
        Debug.Log("Life = " + life);
        Movement(direction);
    }

    private void Movement(Vector3 direction){
        transform.position += (velocity * direction * Time.deltaTime);
    }

    private void Damage(float damageInflicted){
        life -= damageInflicted;
        Debug.Log("Damage inflicted: " + damageInflicted);
    }

    private void Recovery(float healing){
        life += healing;
        Debug.Log("Healing: " + healing);
    }

}
