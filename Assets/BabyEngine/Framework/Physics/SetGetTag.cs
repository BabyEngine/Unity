using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class SetGetTag : MonoBehaviour
{
   public static SetGetTag SetTag(GameObject go,string tag)
   {
      SetGetTag com = go.GetComponent<SetGetTag>();
      if (com == null)
         com = go.AddComponent<SetGetTag>();

      com.Tag = tag;
      return com;
   }
   
   public string Tag;
}
