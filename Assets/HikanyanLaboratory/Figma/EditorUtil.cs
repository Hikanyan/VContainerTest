using System.Collections.Generic;
using System.Reflection;
using HikanyanLaboratory.UISystemTest;
using UnityEngine;

namespace HikanyanLaboratory.Figma
{
    public static class EditorUtil
    {
        public static T AutoAssignForView<T>(GameObject gameObject)
        {
            var autoAssignMap = new Dictionary<string, FieldInfo>();


            var view = gameObject.GetComponent<T>();
            if (view == null) return default;


            foreach (var field in view.GetType()
                         .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var autoAssignByName = field.GetCustomAttribute<AutoAssignByNameAttribute>();
                if (autoAssignByName == null) continue;
                autoAssignMap[autoAssignByName.Name] = field;
            }


            var childrenTransform = gameObject.GetComponentsInChildren<Transform>();
            foreach (var (autoAssignName, field) in autoAssignMap)
            {
                var autoAssignNames = autoAssignName.Split("/");
                foreach (var childTransform in childrenTransform)
                {
                    if (autoAssignNames[0] != childTransform.gameObject.name) continue;

                    var foundTransform = childTransform.parent.Find(autoAssignName);
                    field.SetValue(view, foundTransform.GetComponent(field.FieldType));
                    break;
                }
            }

            return default;
        }
    }
}