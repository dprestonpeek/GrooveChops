using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float maxBottom = CalcMaxBottom();
        Vector3 newPos = transform.localPosition;
        newPos.y = Mathf.Clamp(newPos.y, 0, maxBottom);
        transform.localPosition = newPos;
    }

    float CalcMaxBottom()
    {
        float maxBottom = 0;
        foreach (Song child in GetComponentsInChildren<Song>())
        {
            float bottomOfObj = child.transform.localPosition.y * -1;
            if (bottomOfObj > maxBottom)
            {
                maxBottom = bottomOfObj;
            }
        }
        return maxBottom;
    }
}
