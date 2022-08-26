using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public float scale = 5f;
    /*[SerializeField] private float life = 3f;
    [SerializeField] private float damageInflicted = 0.5f;
    [SerializeField] private float healing = 1f;*/
    [SerializeField] private float velocity = 2f;
    [SerializeField] private Vector3 direction = Vector3.forward;
    private Dictionary<KeyCode, Vector3> movementList =  new Dictionary<KeyCode, Vector3>();
    [SerializeField] private float cameraAxisX = 0f;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private float rayDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale *= scale;
        movementList.Add(KeyCode.W, Vector3.forward);
        movementList.Add(KeyCode.S, Vector3.back);
        //movementList.Add(KeyCode.A, Vector3.left);
        //movementList.Add(KeyCode.D, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        /*Damage(damageInflicted);
        Recovery(healing);
        //Debug.Log("Life = " + life);
        Movement(direction);*/
        RotatePlayer();
        foreach(KeyValuePair<KeyCode, Vector3> movement in movementList)
        {
            if(Input.GetKey(movement.Key))
            {
                Movement(movement.Value);
            }
        }
    }

    private void Movement(Vector3 direction){
        if(!GameManager.HitWall){
            transform.Translate(velocity * direction * Time.deltaTime);
        }
    }

    /*private void Damage(float damageInflicted){
        life -= damageInflicted;
        Debug.Log("Damage inflicted: " + damageInflicted);
    }

    private void Recovery(float healing){
        life += healing;
        Debug.Log("Healing: " + healing);
    }*/

    private void RotatePlayer(){
        cameraAxisX += Input.GetAxis("Mouse X");
        //transform.rotation = Quaternion.Euler(0, 0.1f * cameraAxisX, 0); //el valor 1f lo hace mas sensible al movimiento del mouse.
        Quaternion newRotetion = Quaternion.Euler(0, 2f * cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotetion, 2f * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        PlayerRaycast();
    }

    private void PlayerRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Wall")){
                GameManager.HitWall = true;
                Debug.Log("Hit Wall");
            }
        }else{
            GameManager.HitWall = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
    }
}
