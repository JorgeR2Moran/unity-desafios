using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    private bool decresedSize = false;
    public void ChangeSize(){
        if(decresedSize){
            ScalePlayer(2f);
            decresedSize = false;
        }else{
            ScalePlayer(0.5f);
            decresedSize = true;
        }
        
    }

    private void ScalePlayer(float scale){
        transform.localScale = transform.localScale * scale;
    }
    
    public bool isDecreasedSize(){
        return decresedSize;
    }
}
