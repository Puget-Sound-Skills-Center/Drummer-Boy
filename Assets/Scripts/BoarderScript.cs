using UnityEngine;

public class BoarderScript : MonoBehaviour
{
    public bool inBoarder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inBoarder == true)
        {
            Debug.Log("Note Missed");

            Destroy(gameObject);

            GameManager.instance.NoteMissed();
        }
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boarder")
        {
            inBoarder = true;

            GameManager.instance.NoteMissed();
        }
    }
}
