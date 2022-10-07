using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class LevelManager : MonoBehaviour
{
    /* 
     * require menu scene to have build index 0, end scene to have build index 1, and all other scenes to have build
     * indecies beginning at 2 LEVEL MANAGER WILL NOT FUNCTION WITHOUT THIS CONFIGURATION!!!!!
     */
    int currentHole;
    int holeCount;
    List<Scene> allHoles;
    List<Scene> usedHoles;

    public void gameStart(int holes = 9)
    {
        //load all asset bundless and append to list
        List<AssetBundle> bundles = new List<AssetBundle>(System.IO.Directory.GetFiles(Application.streamingAssetsPath).Length);
        int iterator = 0;
        foreach(string i in System.IO.Directory.GetFiles(Application.streamingAssetsPath))
        {
            bundles[iterator] = AssetBundle.LoadFromFile(i);
            iterator++;
        }
        // get scenes and add to allHoles
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        allHoles = new List<Scene>(sceneCount);
        for(int i = 2; i < sceneCount; i++)
        {
            // get scene by index and add to list skipping scenes 0 and 1
            allHoles[i - 2] = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(i);
        }
        currentHole = 0;
        holeCount = holes;
        // randomize holes list and add to used holes
        var rnd = new System.Random();
        var rndLst = allHoles.OrderBy(item => rnd.Next());
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
        // load next scene
        SceneManager.LoadScene(usedHoles[currentHole].name);
    }

    public void nextLevel()
    {
        currentHole++;
        if(currentHole < holeCount)
        {
            SceneManager.LoadScene(usedHoles[currentHole].name);
        }
        else
        {
            // end behavior
        }
    }
}
