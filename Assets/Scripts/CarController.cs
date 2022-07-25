using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] public float speed;
    [SerializeField] public float sideSpeed = 5;
    [SerializeField] private float wayHalf = 4f;
    private Touch _touch;

    private Vector3 _TouchDown;
    private Vector3 _TouchUp;

    private bool _dragStarted;
    private bool _isMoving;

    private void Start()
    {
        
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _dragStarted = true;
                _isMoving = true;
                _TouchDown = _touch.position;
                _TouchUp = _touch.position;
            }
        }
        if (_dragStarted)
        {
            if (_touch.phase == TouchPhase.Moved)
            {
                _TouchDown = _touch.position;
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                _TouchDown = _touch.position;
                _isMoving = false;
                _dragStarted = false;
            }
            gameObject.transform.Translate(CalculateDirection() * sideSpeed * Time.deltaTime);

            if (transform.position.x <= -wayHalf)
            {
                Vector3 _position = new Vector3(-wayHalf, transform.position.y, transform.position.z);
                transform.position = _position;
            }
            else if (transform.position.x >= wayHalf)
            {
                Vector3 _position = new Vector3(wayHalf, transform.position.y, transform.position.z);
                transform.position = _position;
            }
        }
        
       
    }
    Vector3 CalculateDirection()
    {
        Vector3 temp = (_TouchDown - _TouchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            sideSpeed = 0;   
        }
    }
}



