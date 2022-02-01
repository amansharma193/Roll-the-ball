using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballcontroller : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Text countText;
    public Text winText;
    private int count;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count=0;
        setCountText();
        winText.text="";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("pickup")){
            other.gameObject.SetActive(false);
            count+=1;
            setCountText();
        }
    }
    void setCountText(){
        countText.text="Score: "+count.ToString();
        if(count>=25){
            winText.text="You Won!!";
        }
    }
}
