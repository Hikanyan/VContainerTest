using System;
using UnityEngine;

namespace HikanyanLaboratory.UI
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PrefabReferenceAttribute : PropertyAttribute
    {
        public string PrefabKey { get; private set; }

        public PrefabReferenceAttribute(string prefabKey)
        {
            PrefabKey = prefabKey;
        }
    }
}