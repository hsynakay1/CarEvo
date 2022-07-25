using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject[] cars;
    [SerializeField] private TMP_Text totalYearText;

    private int index;
    private int totalYears = 1950;
    public bool finish = false;

    CarController carController;
    private void Start()
    {
        carController = GetComponent<CarController>();
        totalYearText.text = totalYears.ToString(); 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("upgrade") || other.transform.CompareTag("downgrade"))
        {

            int yearOffset = other.transform.GetComponent<Door>().yearsValue;

            totalYears += yearOffset;

            SetPlayerLevel(totalYears);

            Debug.Log(totalYears);
        }
        if (other.gameObject.CompareTag("platform"))
        {
            if (index == 0)
            {
                transform.DOMoveY(0.5f, 1);
            }
            else if (index == 1)
            {
                transform.DOMoveY(1.5f, 1);
            }
            else if (index == 2)
            {
                transform.DOMoveY(2.5f, 1.2f);
            }
            else if (index == 3)
            {
                transform.DOMoveY(3.5f, 1.3f);
            }
            else if (index == 4)
            {
                transform.DOMoveY(4.5f, 1.4f);
            }
            else if (index == 5) 
            {
                transform.DOMoveY(5.5f, 1.5f);
            }
            else if (index == 6)
            {
                transform.DOMoveY(6.5f, 1.6f);
            }
           
        }
        if (other.gameObject.CompareTag("point"))
        {
            other.gameObject.transform.DOScaleX(2, 1);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            other.gameObject.transform.DOScaleX(1, 1);
        }
    }

    void SetPlayerLevel(int years)
    {
       
      if (years <= 1950 && years < 1960)
        {
            index = 0;
        }
        else if (years >= 1960 && years < 1970)
        {
            index = 1;
        }
        else if (years >= 1970 && years < 1980)
        {
            index = 2;
        }
        else if (years >= 1980 && years < 1990)
        {
            index = 3;
        }
        else if (years >= 1990 && years < 2000)
        {
            index = 4;
        }
        else if (years >= 2000 && years < 2010)
        {
            index = 5;
        }
        else if (years >= 2022 )
        {
            index = 6;
        }
        foreach (GameObject item in cars)
        {
            item.SetActive(false);
        }

        cars[index].SetActive(true);
        totalYearText.text = totalYears.ToString();
    }
   
}







