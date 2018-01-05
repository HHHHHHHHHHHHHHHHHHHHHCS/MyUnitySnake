using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    /// <summary>
    /// X 左边  Y 下边  Z 右边  W 上边
    /// </summary>
    [SerializeField]
    private Vector4 border;
    [SerializeField]
    private Transform left, down, right, up;


    public Vector4 Border { get { return border; } }
    public Transform Left { get { return left; } }
    public Transform Down { get { return down; } }
    public Transform Right { get { return right; } }
    public Transform Up { get { return up; } }
}
