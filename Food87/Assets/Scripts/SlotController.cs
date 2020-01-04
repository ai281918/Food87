using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameObject[] items;
    Vector3 startPosition, itemGap;
    string[] _contents = new string[]{""};
    public string[] contents{
        get{
            return _contents;
        }
        set{
            _contents = value;
            currentItem = 0;
            for(int i=0;i<items.Length;++i){
                if(currentItem == _contents.Length){
                    currentItem = 0;
                }
                items[i].transform.GetChild(0).GetComponent<Text>().text = contents[currentItem++];
            }
        }
    }
    [HideInInspector]
    public string result = "";
    float movingTime = 0.1f;
    bool stop = false;
    int currentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = items[0].transform.position;
        itemGap = items[1].transform.position - items[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(){
        stop = false;
        StartCoroutine(moveItem(5));
    }

    public void GameStop(){
        stop = true;
    }

    IEnumerator moveItem(int speedCount){
        float timeCount = 0f;
        while(timeCount < movingTime*speedCount){
            timeCount += Time.deltaTime;
            for(int i=0;i<items.Length;++i){
                items[i].transform.position = Vector3.Lerp(startPosition+i*itemGap, startPosition+(i+1)*itemGap, timeCount/(movingTime*speedCount));
            }
            yield return 0;
        }


        GameObject t = items[items.Length-1];
        for(int i=items.Length-2;i>=0;--i){
            items[i].transform.position = startPosition+(i+1)*itemGap;
            items[i+1] = items[i];
        }
        t.transform.position = startPosition;
        items[0] = t;

        if(stop){
            if(speedCount != 5){
                StartCoroutine(moveItem(speedCount+1));
            }
        }
        else{
            StartCoroutine(moveItem(Mathf.Max(speedCount-1, 1)));
        }
    }
}
