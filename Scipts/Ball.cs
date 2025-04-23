using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController m_gc;
    public GameObject destroyEffect; 
    public AudioClip destroySound; 
    private AudioSource audioSource; 

    private void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            m_gc.IncrementScore();
            PlayDestroySound(); 
            ShowDestroyEffect(); 
            Destroy(gameObject); 
            Debug.Log("Qua bong da va cham voi gia do");
        }
        else if (col.gameObject.CompareTag("DeathZone"))
            Debug.Log("Qua bong va cham DeathZone. GameOver");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone"))
        {
            m_gc.IsGameover = true;
            PlayDestroySound(); 
            ShowDestroyEffect(); 
            Destroy(gameObject); 
            Debug.Log("Qua bong va cham DeathZone. GameOver");
        }
    }

    private void ShowDestroyEffect()
    {
        if (destroyEffect != null)
        {
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    private void PlayDestroySound()
    {
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position); 
        }
    }
}
