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
     */

    int currentHole;
    int holeCount;
    List<Scene> allHoles;
    List<Scene> usedHoles;

    public void gameStart(int holes = 9)
    {
        // load all asset bundless and append to list
        // determine number of total asset bundles
        // create lists for scenes and other
        List<AssetBundle> sceneBundles = new List<AssetBundle>(System.IO.Directory.GetFiles(Application.streamingAssetsPath).Length / 4);
        List<AssetBundle> otherBundles = new List<AssetBundle>(System.IO.Directory.GetFiles(Application.streamingAssetsPath).Length / 4); 
        int sceneBundleIterator = 0;
        int otherBundleIterator = 0;
        // assign each bundle to an index
        foreach(string i in System.IO.Directory.GetFiles(Application.streamingAssetsPath))
        {
            // check for not meta files
            if(!i.Contains(".meta"))
            {
                // separate bundles into scenes and other
                if(i.Contains("scene"))
                {
                    sceneBundles[sceneBundleIterator] = AssetBundle.LoadFromFile(i);
                    sceneBundleIterator++;
                }
                else
                {
                    otherBundles[otherBundleIterator] = AssetBundle.LoadFromFile(i);
                    otherBundleIterator++;
                }
            }
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
