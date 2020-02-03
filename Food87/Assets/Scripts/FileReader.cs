using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FileReader : MonoBehaviour
{
    public SlotController slotController;
    public string fileName;

    // Start is called before the first frame update
    void Start()
    {
        print(Application.dataPath);
        ReadFile(Application.dataPath+"/"+fileName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadFile(string filePath){
        StreamReader sr = new StreamReader(filePath);
        slotController.contents = sr.ReadToEnd().Split('\n');
    }
}
