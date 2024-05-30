using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float ziplama = 10f;
    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public string CurrentColor;

    public Color ColorCam;
    public Color ColorSari;
    public Color ColorPembe;
    public Color ColorEflatun;

    
    public Text txt,score,hing;
    public int deger,number;

    public GameObject bir,iki,uc,dort,panel;
    

    void Start()
    {
        RandomColor();
        rb.bodyType = RigidbodyType2D.Static;
        panel.SetActive(false);
        hing.text=(PlayerPrefs.GetInt("HinghScore",0)).ToString();
    }

  
    void Update(){
         txt.text= deger.ToString("f0");


        if((Input.GetButtonDown("Jump")) || (Input.GetMouseButtonDown(0))){
           rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * ziplama;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
    if(col.tag == "ColorChanger"){
      col.gameObject.transform.position=transform.position + new Vector3(0f, 25f, 0f);
      bir.transform.position=transform.position + new Vector3(0f,19f,0f);
      deger +=1;
      number+=1;
      score.text=number.ToString();
      if(number>PlayerPrefs.GetInt("HinghScore", 0)){
        PlayerPrefs.SetInt("HinghScore",number);
        hing.text = number.ToString();
      }
      RandomColor();
      return;
    }
    if(col.tag == "two"){
      col.gameObject.transform.position=transform.position + new Vector3(0f, 25f, 0f);
      iki.transform.position=transform.position + new Vector3(0f,19f,0f);
      deger +=1;
       number+=1;
      score.text=number.ToString();
      if(number>PlayerPrefs.GetInt("HinghScore", 0)){
        PlayerPrefs.SetInt("HinghScore",number);
        hing.text = number.ToString();
      }
      RandomColor();
      return;
    }
    if(col.tag == "three"){
      col.gameObject.transform.position=transform.position+ new Vector3(0f, 25f, 0f);
      uc.transform.position=transform.position + new Vector3(0f,19f,0f);
       dort.transform.position=transform.position + new Vector3(0f,19f,0f);
      deger +=1;
       number+=1;
      score.text=number.ToString();
      if(number>PlayerPrefs.GetInt("HinghScore", 0)){
        PlayerPrefs.SetInt("HinghScore",number);
        hing.text = number.ToString();
      }
      RandomColor();
      return;
    }


    if(col.tag != CurrentColor){
        Debug.Log("Game Over!");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panel.SetActive(true);
        Time.timeScale=0;
    }
    if(col.tag == "Respawn"){
     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    panel.SetActive(true);
        Time.timeScale=0;
    }


    }
    void RandomColor(){
        int index = Random.Range(0, 4);

        switch(index){
        case 0: CurrentColor= "Cam";
        sr.color = ColorCam;
         break;
         case 1: CurrentColor="Sari";
         sr.color = ColorSari;
         break;
         case 2: CurrentColor= "Pembe";
         sr.color = ColorPembe;
         break;
         case 3: CurrentColor="Eflatun";
         sr.color = ColorEflatun;
         break;
        }
    }
   public void Play(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    panel.SetActive(false);
    Time.timeScale = 1;
   }
  public void Replay(){
   this.transform.position = transform.position = new Vector3(0f, 1.5f ,0f);
    panel.SetActive(false);
    Time.timeScale= 1;
    rb.bodyType = RigidbodyType2D.Static;
  }
}
