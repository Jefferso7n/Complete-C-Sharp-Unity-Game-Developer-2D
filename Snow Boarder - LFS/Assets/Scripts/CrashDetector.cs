using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] PlayerController playerController;
    bool hasCrashed = false;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && !hasCrashed){
            hasCrashed = true;
            playerController.DisableControls();

            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene("Level1");
    }
}
