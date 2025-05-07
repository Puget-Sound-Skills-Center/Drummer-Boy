using UnityEngine;
using UnityEngine.Tilemaps;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode KeyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

               // GameManager.instance.NoteHit();

                if(Mathf.Abs (transform.position.y) > 0.25)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                } 
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good Hit");
                    GameManager.instance.GoodHit();
                }
                else if (Mathf.Abs(transform.position.y) > 0f)
                {
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                }
              //  else if (Mathf.Abs(transform.position.y) > .50f)
              //  {
                //    Debug.Log("Bad Hit");
                  //  GameManager.instance.BadHit();
               // }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
            }
        }
    }
}
