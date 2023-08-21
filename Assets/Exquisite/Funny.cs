using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Funny : MonoBehaviour
{

    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }

    private void Update()
    {
        foreach (GameObject go in GetAllObjectsOnlyInScene())
        {
            if (go.name.Contains("a"))
            {
                Debug.Log(go.name + " contains the letter a");
            }
            else if (go.name.Contains("b"))
            {
                Debug.Log(go.name + " contains the letter b");
            }
            else if (!go.name.Contains("c"))
            {
                Debug.Log(go.name + " contains the letter c");
            }
            else if (go.name.Contains("d"))
            {
                Debug.Log(go.name + " contains the letter d");
            }
            else if (go.name.Contains("e"))
            {
                Debug.Log(go.name + " contains the letter e");
            }
            else if (go.name.Contains("f"))
            {
                Debug.Log(go.name + " contains the letter f");
            }
            else if (go.name.Contains("g"))
            {
                Debug.Log(go.name + " contains the letter g");
            }
            else if (go.name.Contains("h"))
            {
                Debug.Log(go.name + " contains the letter h");
            }
            else if (go.name.Contains("i"))
            {
                Debug.Log(go.name + " contains the letter i");
            }
            else if (go.name.Contains("j"))
            {
                Debug.Log(go.name + " contains the letter j");
            }
            else if (go.name.Contains("k"))
            {
                Debug.Log(go.name + " contains the letter k");
            }
            else if (go.name.Contains("l"))
            {
                Debug.Log(go.name + " contains the letter l");
            }
            else if (go.name.Contains("m"))
            {
                Debug.Log(go.name + " contains the letter m");
            }
            else if (go.name.Contains("n"))
            {
                Debug.Log(go.name + " contains the letter n");
            }
            else if (go.name.Contains("o"))
            {
                Debug.Log(go.name + " contains the letter o");
            }
            else if (go.name.Contains("p"))
            {
                Debug.Log(go.name + " contains the letter p");
            }
            else if (go.name.Contains("q"))
            {
                Debug.Log(go.name + " contains the letter q");
            }
            else if (go.name.Contains("r"))
            {
                Debug.Log(go.name + " contains the letter r");
            }
            else if (go.name.Contains("s"))
            {
                Debug.Log(go.name + " contains the letter s");
            }
            else if (go.name.Contains("t"))
            {
                Debug.Log(go.name + " contains the letter t");
            }
            else if (go.name.Contains("u"))
            {
                Debug.Log(go.name + " contains the letter u");
            }
            else if (go.name.Contains("v"))
            {
                Debug.Log(go.name + " contains the letter v");
            }
            else if (go.name.Contains("w"))
            {
                Debug.Log(go.name + " contains the letter w");
            }
            else if (go.name.Contains("x"))
            {
                Debug.Log(go.name + " contains the letter x");
            }
            else if (go.name.Contains("y"))
            {
                Debug.Log(go.name + " contains the letter y");
            }
            else if (go.name.Contains("z"))
            {
                Debug.Log(go.name + " contains the letter z");
            }
            else
            {
                Debug.Log(go.name + " does not contain a letter");
            }

        }
    }
}

