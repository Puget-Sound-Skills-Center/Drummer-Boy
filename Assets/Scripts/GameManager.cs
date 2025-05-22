using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    [Header("---------- Aduio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Aduio Clip ---------")]
    public AudioClip mainMenu_Music;
    public AudioClip Tutorial_Music;
    public AudioClip Win_Effect;
    public AudioClip Tutorial_Extended;
    public AudioClip button_click;

    private static AudioManager audioInstance;

    public AudioSource theMusic;

    public bool startPlaying;
    
    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;


    public Text scoreText;
    public Text multiText;
  //  public Text tultorialText;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;
    

   // public GameObject tutText;
    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    AudioManager audioManager;

    private void Awake()
    {
     //   audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
       
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
      }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

              //  musicSource.Play();
                theMusic.Play();
            }
        }
        else
        {
         
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {


                    //  SceneManager.LoadSceneAsync("Win Screen");
                    resultsScreen.SetActive(true);


                    normalsText.text = "" + normalHits;
                    goodsText.text = goodHits.ToString();
                    perfectsText.text = perfectHits.ToString(); ;
                    missesText.text = missedHits.ToString(); ;

                    float totalHit = normalHits + goodHits + perfectHits;
                    float percentHit = (totalHit / totalNotes) * 100f;

                    percentHitText.text = percentHit.ToString("F1") + "%";

                    string rankVal = "F";
                    rankText.color = Color.red;

                if (currentScore >= 20000)
                    {
                        rankVal = "D";
                        rankText.color = Color.blue;
                      if (currentScore >= 30000)
                      {
                        rankVal = "C";
                        rankText.color = Color.yellow;
                        if (currentScore >= 45000)
                        {
                            rankVal = "B";
                            rankText.color = Color.cyan;
                            if (currentScore >= 60000)
                            {
                                rankVal = "A";
                                rankText.color = Color.green;
                                if (currentScore >= 70000)
                                {
                                    rankVal = "S";
                                    rankText.color = Color.magenta;
                                    if (currentScore >= 88800)
                                    {
                                        rankVal = "Nerd";
                                        rankText.color = Color.black;
                                    }
                                }
                            }
                        }
                      }
                 }
                 rankText.text = rankVal;

                 finalScoreText.text = currentScore.ToString();
            }
         
        }  
    }


    public void NoteHit()
    {
        

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

      //  currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }



    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
            Debug.Log("Missed Note");

            currentMultiplier = 1;
            multiplierTracker = 0;

            multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }
}
