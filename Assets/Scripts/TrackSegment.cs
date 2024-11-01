using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrackType
{
    JUMP_LEVEL,
    NORMAL_LEVEL
}
public class TrackSegment : MonoBehaviour
{
    public TrackType trackType;
    public Transform pivot;
}
