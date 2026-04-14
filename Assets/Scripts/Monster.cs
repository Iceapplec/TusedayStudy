using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Animations;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        {
            string[] texts = new string[10];

            List<int> testList = new List<int>();

            List<Human> humans = new List<Human>();

            Human man2 = new Human();
            man2.name ="맨투맨";

            humans.Add(man2);

            for(int i = 0; i < humans.Count; i++)
            {

            }

        }

        int z = 0;

        while (z < 10)
        {
            Debug.Log("*");
            z++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * 0.03f;
        //transform.position -= Vector3.left * -0.03f;
        //transform.position += Vector3.up * 0.03f;
        //transform.position -= Vector3.down * -0.03f;
        //transform.Translate(Vector3.right * 0.03f);

        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.03f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.03f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.03f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.03f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * 0.03f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 0.03f);
        }
    }

    public void invite(Human newUser)
    {
        
    }

    public void Mention()
    {

    }
}
