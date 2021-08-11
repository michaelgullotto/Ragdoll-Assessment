using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject IntroPanel;
    [SerializeField]  Text score;
    private bool scoreCounting = false;
    [SerializeField] private GameObject GameEndpanel;
    [SerializeField] private GameObject lame;
    [SerializeField] private GameObject epic;
    [field: SerializeField] public GameObject Goodtry;
    [SerializeField] private GameObject nice;
    [SerializeField] private float endScore;
    [SerializeField] private Text endScoreDis;

    public static float Totalscore;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        IntroPanel.SetActive(true);
        score.GetComponent<Text>();
        endScoreDis.GetComponent<Text>();
        scoreCounting = false;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + Totalscore;

        if (Totalscore > 1 && !scoreCounting)
        {
            StartCoroutine(Scoreing());
        }
    }

    public void startGame()
    {
        IntroPanel.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator Scoreing()
    {
        scoreCounting = true;
        float time = 0;
        while (time < 12)
        {
            time++;
            yield return new WaitForSeconds(1);
        }
        GameEndpanel.SetActive(true);
        endScore = Totalscore;
        if (Totalscore < 250)
        {
            lame.SetActive(true);
        }
        if (Totalscore >= 250 && Totalscore < 500)
        {
            Goodtry.SetActive(true);
        }
        if (Totalscore < 750 && Totalscore >=500)
        {
            nice.SetActive(true);
        }
        if (Totalscore >= 750)
        {
            epic.SetActive(true);
        }

        endScoreDis.text = endScore.ToString();

    }

    public void Retry()
    {
        Totalscore = 0;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
