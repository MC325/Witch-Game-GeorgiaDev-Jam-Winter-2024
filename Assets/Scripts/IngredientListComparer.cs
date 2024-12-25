using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WCG;

public class IngredientListComparer : IEqualityComparer<IngredientType[]>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Equals(IngredientType[] x, IngredientType[] y)
    {
        if (x.Length != y.Length)
        {
            return false;
        }
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }
        return true;
    }

    public int GetHashCode(IngredientType[] obj)
    {
        int result = 1;
        for (int i = 0; i < obj.Length; i++)
        {
            unchecked
            {
                result = result * 23 + (int) obj[i];
            }
        }
        return result;
    }
}