using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject ultraball;
    public GameObject masterball;
    public float spawnTime;
    float m_spawnTime;

    private AudioSource audioSource;
    public AudioClip destroySound;

    int m_score;
    bool m_isGameover;
    bool m_startGame;
    Line m_Logo;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score.ToString());
        m_Logo = FindObjectOfType<Line>();
        audioSource = GetComponent<AudioSource>();
        m_startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startGame)
        {
            m_spawnTime -= Time.deltaTime;

            if (m_isGameover)
            {
                m_spawnTime = 0;
                m_ui.ShowGameoverPanel(true);
                m_ui.ShowMainUI(false);
                return;
            }

            if (m_spawnTime <= 0)
            {
                SpawnBall();
                m_spawnTime = spawnTime;
            }
        }
        if (checkWin())
        {
            PlayDestroySound();
        }
        if (m_score == 500)
            m_ui.ShowCongratulationsUI(true);
    }

    public void SpawnBall()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-6, 6), 4);
        Vector2 spawnPos1 = new Vector2(Random.Range(-6, 6), 3);

        if (ball == true && m_score < 20)
        {
            Instantiate(ball, spawnPos, Quaternion.identity);
        }
        else if (ultraball == true && m_score < 200)
        {
            spawnTime = 1;
            Instantiate(ultraball, spawnPos, Quaternion.identity);
        }
        else if (masterball == true && m_score < 500)
        {
            spawnTime = 1.5f;
            Instantiate(masterball, spawnPos1, Quaternion.identity);
        }
    }

    public void Replay()
    {
        m_score = 0;
        m_isGameover = false;
        m_ui.SetScoreText("Score: " + m_score.ToString());
        m_ui.ShowGameoverPanel(false);
        m_ui.ShowMainUI(true);
        m_ui.ShowCongratulationsUI(false);
        spawnTime = 2;
        // m_Logo.Replay();
    }
    public void start()
    {
        m_ui.ShowstartGame(false);
        m_ui.ShowMainUI(true);
        m_startGame = true;
       // m_Logo.Replay();
    }
    public int Score
    {
        get { return m_score; }
        set { m_score = value; }
    }

    public void IncrementScore()
    {
        if (m_score < 20)
            m_score++;
        else
            if (m_score >= 20 && m_score < 200)
            m_score += 2;
        else if (m_score >= 200)
            m_score += 5;
        m_ui.SetScoreText("Score: " + m_score.ToString());
    }

    public bool IsGameover
    {
        get { return (m_isGameover); }
        set { m_isGameover = value; }
    }
    public bool startGame
    {
        get { return (m_startGame); }
        set { m_startGame = value; }
    }

    private void PlayDestroySound()
    {
        if (destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
        }
    }

    private bool checkWin()
    {
        if (m_score == 20 || m_score == 200 || m_score == 500)
            return true;
        return false;
    }    
}
