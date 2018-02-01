using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Postcat/LevelSpec")]
public class LevelSpec : ScriptableObject {

    private int level;
    private int totalSections;
    private int[] lvlsMaxLenght;

    // Use this for initialization
    public LevelSpec(int levelNumber) {
        this.level = levelNumber;
        //Should be more than 1, 2+
        lvlsMaxLenght = new[] { 2, 3, 6, 8, 11, 8, 9, 13 };

        GenerateLevel();
    }

    public int maxSectionNumber {
        get {
            return totalSections;
        }
    }


    void GenerateLevel() {
        if (this.level < lvlsMaxLenght.Length) {
            totalSections = lvlsMaxLenght[level];
        } else {
            totalSections = (int)Mathf.Round(Random.Range(8, 16));

        }
        // Debug.Log("Distance " + _maxSectionNumber);
    }
}
