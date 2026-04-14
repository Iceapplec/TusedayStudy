using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CardController : MonoBehaviour
{
    public float rotateY;
    public TextMeshProUGUI text;
    public bool isFront = true;
    private Quaternion flipRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion originalRotation = Quaternion.Euler(0, 0, 0);
    public int number;
    public CardGame cardGame;
    public bool isMatched = false;
 


    void Start()
    {
        
    }

    void Update()
    {
        float currentY = transform.eulerAngles.y;

        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, rotateY * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipRotation, rotateY * Time.deltaTime);
        }
       

    }

    public void ClickCard()
    {
        if (isMatched)
        {

        }
        else
        {
            cardGame.OnClickCard(this);
  
        }

    }

    public void Flip(bool isFront)
    {
        this.isFront = isFront;
    }


    public void SetCardNumber(int newNumber)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        number = newNumber;
        text.text = number.ToString();
    }

    public void ChangeColor(Color newcolor)
    {
        GetComponent<Image>().color = newcolor;
    }

    public void SetImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
