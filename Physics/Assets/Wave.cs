using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public enum Condition{
        Crest,
        Trough
    };

    int segments = 1000;
    public float radius;
    LineRenderer line;
    public Condition condition = Condition.Trough;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;

        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, z));
            angle += (360f / segments);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (condition == Condition.Crest)
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        else if (condition == Condition.Trough)
        {
            line.startColor = Color.blue;
            line.endColor = Color.blue;
        }
    }

    public void ChangeCondition()
    {
        if (condition == Condition.Crest)
        {
            condition = Condition.Trough;
        }
        else
        {
            condition = Condition.Crest;
        }
    }
}
