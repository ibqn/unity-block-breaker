using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float minimalPosition;
    [SerializeField] float maximalPosition;


    // Update is called once per frame
    void Update()
    {
        float xPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minimalPosition, maximalPosition);

        // Debug.Log(xPosition);

        transform.position = new Vector2(xPosition, transform.position.y);
    }
}
