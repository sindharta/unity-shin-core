using System;
using UnityEditor;
using UnityEngine;

namespace org.shin.utilities {

public static class UnityEditorUtility  {

//---------------------------------------------------------------------------------------------------------------------

    public static void CreatePrimitiveObject(string primitiveTypeName) {    
        PrimitiveType pt = (PrimitiveType) Enum.Parse (typeof(PrimitiveType), primitiveTypeName, true);
        CreatePrimitiveObject(pt);
    }

//---------------------------------------------------------------------------------------------------------------------

    public static void CreatePrimitiveObject(PrimitiveType pt) {    
        GameObject go = ObjectFactory.CreatePrimitive(pt);
        go.transform.position = Vector3.zero;
    }

}

}
