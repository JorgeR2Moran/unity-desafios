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
    private Dictionary<KeyCode, Vector3> movementList =  new Dictionary<KeyCode, Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale *= scale;
        movementList.Add(KeyCode.W, Vector3.forward);
        movementList.Add(KeyCode.S, Vector3.back);
        movementList.Add(KeyCode.A, Vector3.left);
        movementList.Add(KeyCode.D, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        /*Damage(damageInflicted);
        Recovery(healing);
        //Debug.Log("Life = " + life);
        Movement(direction);*/

        foreach(KeyValuePair<KeyCode, Vector3> movement in movementList)
        {
            if(Input.GetKey(movement.Key))
            {
                Movement(movement.Value);
            }
        }
    }

    private void Movement(Vector3 direction){
        transform.Translate(velocity * direction * Time.deltaTime);
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
