using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveYoyoY : MonoBehaviour
{
    public float moveDistance = 3f;
    public float duration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(transform.position.y-moveDistance, duration).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
