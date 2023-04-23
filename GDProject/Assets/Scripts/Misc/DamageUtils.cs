using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUtils
{
    public static void GetInterfaces<T>(out List<T> resultList, GameObject objectToSearch) where T : class
    {
        if (objectToSearch == null)
        {
            resultList = new List<T>();
            return;
        }

        MonoBehaviour[] list = objectToSearch.GetComponents<MonoBehaviour>();
        resultList = new List<T>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is T)
            {
                resultList.Add((T)((System.Object)mb));
            }
        }
    }

    public static IEnumerator ChangeColorOnGamage(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSecondsRealtime(0.15f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
