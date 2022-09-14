using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip backAudio;
    [SerializeField] private AudioClip enemyAudio;
    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        PlayerMovement.OnMoveBackwards += PlayerBackMovement;
        EnemyManager.OnEnemyCreated += EnemyAudio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerBackMovement(){
        Debug.Log("OnMoveBackwards - Received - AudioManager");
        PlayAudio(backAudio);
    }

    private void EnemyAudio(){
        Debug.Log("OnEnemyCreated - Received - AudioManager");
        PlayAudio(enemyAudio);
    }

    private void PlayAudio(AudioClip audioClip){
        if(!audioPlayer.isPlaying){
            audioPlayer.PlayOneShot(audioClip);
        }
    }
}
