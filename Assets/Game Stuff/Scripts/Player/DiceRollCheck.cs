using System.Collections.Generic;
using UnityEngine;

public class DiceRollCheck : MonoBehaviour
{
    [SerializeField] int num;

    [SerializeField] Vector3Int DirectionValues;
    Vector3Int OpposingDirectionValues;

    readonly List<int> FaceRepresent = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

    void Start()
    {
        OpposingDirectionValues = 7 * Vector3Int.one - DirectionValues;
    }

    void Update()
    {
        if (transform.hasChanged)
        {
            if (Vector3.Cross(Vector3.up, transform.right).magnitude < 0.5f) // x axis
            {
                if (Vector3.Dot(Vector3.up, transform.right) > 0)
                {
                    num = FaceRepresent[DirectionValues.x];
                }
                else
                {
                    num = FaceRepresent[OpposingDirectionValues.x];
                }
            }
            else
            if (Vector3.Cross(Vector3.up, transform.up).magnitude < 0.5f) //y axis
            {
                if (Vector3.Dot(Vector3.up, transform.up) > 0)
                {
                    num = FaceRepresent[DirectionValues.y];
                }
                else
                {
                    num = FaceRepresent[OpposingDirectionValues.y];
                }
            }
            else
            if (Vector3.Cross(Vector3.up, transform.forward).magnitude < 0.5f) //z axis
            {
                if (Vector3.Dot(Vector3.up, transform.forward) > 0)
                {
                    num = FaceRepresent[DirectionValues.z];
                }
                else
                {
                    num = FaceRepresent[OpposingDirectionValues.z];
                }
            }

            switch(num)
            {
                case 1:
                    num = 4;
                    break;

                case 2:
                    num = 5;
                    break;

                case 3:
                    num = 6;
                    break;

                case 4:
                    num = 1;
                    break;

                case 5:
                    num = 2;
                    break;

                case 6:
                    num = 3;
                    break;
            }
            transform.hasChanged = false;
        }
    }
}