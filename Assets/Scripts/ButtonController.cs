using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode KeyToPress;
    public KeyCode SecondaryKeyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress) || Input.GetKeyDown(SecondaryKeyToPress))
        {
            theSR.sprite = pressedImage;
          
        }

        if (Input.GetKeyUp(KeyToPress) || Input.GetKeyDown(SecondaryKeyToPress))
        {
            theSR.sprite = defaultImage;
           
        }
    }
}
