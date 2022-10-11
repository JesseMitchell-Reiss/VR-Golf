using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class LevelManager : MonoBehaviour
{
    /* 
     * All assets that are not C# scripts must be stored in asset bundles within the /Assets/StreamingAssets directory
     * They must be bundled up into two separate bundles per student, one for the scene and one for assets
     * All C# scripts must be stored in a separate folder and compiled with the project
     * start scene must have build index 0
     * end scene must have build index 1
     */

    int currentHole;
    int holeCount;
    List<string> usedHoles;
    public int score;

    public void gameStart(int holes = 9)
    {
        // set score to 0
        score = 0;
        // initialize holescores
        ScoreTracker.levelScores = new int[holes];
        // create lists for scenes and other
        List<string> scenePaths = new List<string>(System.IO.Directory.GetFiles(Application.streamingAssetsPath).Length / 4);
        List<string> otherPaths = new List<string>(System.IO.Directory.GetFiles(Application.streamingAssetsPath).Length / 4); 
        int scenePathIterator = 0;
        int otherPathIterator = 0;
        // assign each bundle to an index
        foreach(string i in System.IO.Directory.GetFiles(Application.streamingAssetsPath))
        {
            // check for not meta files
            if(!i.Contains(".meta"))
            {
                // separate bundles into scenes and other
                if(i.Contains("scene"))
                {
                    scenePaths[scenePathIterator] = i;
                    scenePathIterator++;
                }
                else
                {
                    otherPaths[otherPathIterator] = i;
                    otherPathIterator++;
                }
            }
        }
        // load all non scene assets from bundles
        foreach (string i in otherPaths)
        {
            AssetBundle.LoadFromFile(i).LoadAllAssets();
        }
        // randomize holes list and add to used holes
        var rnd = new System.Random();
        var rndLst = scenePaths.OrderBy(item => rnd.Next());
        int index = 0;
        foreach(var scene in rndLst)
        {
            if (index < holeCount)
            {
                usedHoles.Add(scene);
                index++;
            }
            else
                break;
        }
        // load first scene
        holeCount = usedHoles.Count;
        currentHole = 0;
        SceneManager.LoadScene(AssetBundle.LoadFromFile(usedHoles[currentHole]).GetAllScenePaths()[0]);
    }

    public void nextLevel()
    {
        ScoreTracker.levelScores[currentHole] = score;
        currentHole++;
        if(currentHole < holeCount)
        {
            // load next scene
            SceneManager.LoadScene(AssetBundle.LoadFromFile(usedHoles[currentHole]).GetAllScenePaths()[0]);
        }
        else
        {
            // end behavior
            SceneManager.LoadScene(1);
        }
    }
}
