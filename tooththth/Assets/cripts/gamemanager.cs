using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderKeywordFilter;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject card;
    float time = 0.0f;
    public static gamemanager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endTxt;
    public Sprite specialImage0;
    public Sprite specialImage1;
    public Sprite specialImage2;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };

        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);



            Time.timeScale = 1.0f;
        }
    }



    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            
            
            if (firstCardImage == "rtan0" )
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage0;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage0;
            }
            else if (firstCardImage == "rtan1")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage0;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage0;
            }
            else if (firstCardImage == "rtan2")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
            }
            else if (firstCardImage == "rtan3")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
            }
            else if (firstCardImage == "rtan4")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage1;
            }
            else if (firstCardImage == "rtan5")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
            }
            else if (firstCardImage == "rtan6")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
            }
            else if (firstCardImage == "rtan7")
            {
                firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
                secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = specialImage2;
            }
          

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;


     

    }
}
