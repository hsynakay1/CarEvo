using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenManager : MonoBehaviour
{
   
    void Start()
    {
        DOTween.Init();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("okey");
            transform.DOLocalMove(new Vector3(0, 0.54f, 346.5f), 1.5f);
        }
        
    }
    
}
