using UnityEngine;

public class End_Object_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) < 0)
        {
          //  Debug.Log("END IS NOW!!!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("END IS NOW!!!!!");


    }
}
