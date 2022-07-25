using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{

    enum EDoorType { Upgrade, DownGrade };

    [Header("Type")]
    [SerializeField] private EDoorType doorType;

    [Header("Material")]
    [SerializeField] private Material upgradeMaterial;
    [SerializeField] private Material downgradeMaterial;

    [Header("Properties")]
    public int yearsValue = 150;

    [SerializeField] private TMP_Text textYears;

    private void OnValidate()
    {
        if (doorType == EDoorType.Upgrade)
        {
            gameObject.tag = "upgrade";
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = upgradeMaterial;
            textYears.text = "+" + yearsValue.ToString();
        }
        else if (doorType == EDoorType.DownGrade)
        {
            gameObject.tag = "downgrade";
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = downgradeMaterial;
            textYears.text = yearsValue.ToString();
        }




    }


}
