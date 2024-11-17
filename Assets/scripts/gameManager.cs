using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class agmeManager : MonoBehaviour
{

    Vector3 resetCarPosition;
    [SerializeField] GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        resetCarPosition = car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            car.transform.position = resetCarPosition;
        }

        if (car.transform.position.y <= -10)
        {
            resetCarPosition.y = 10;
            car.transform.position = resetCarPosition;
        }
    }
}
