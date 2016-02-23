using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(mInspector)), CanEditMultipleObjects]
public class PropiedadesInspector : Editor
{
    // Propiedades serializables
    public SerializedProperty
        estado_Prop,
        slider_Prop,
        mString_Prop,
        mObj_Prop,
        mTransform_Prop;


    // Busca la propiedad y activa la vista
    void OnEnable()
    {
        estado_Prop = serializedObject.FindProperty("estado");
        slider_Prop = serializedObject.FindProperty("slider");
        mTransform_Prop = serializedObject.FindProperty("mTransform");
        mString_Prop = serializedObject.FindProperty("name");
        mObj_Prop = serializedObject.FindProperty("obj");
    }


    // Muestra en el inspector
    public override void OnInspectorGUI()
    {
        // Update
        serializedObject.Update();

        // Muestra enum Estado
        EditorGUILayout.PropertyField(estado_Prop);

        // Captura el evento del estado
        mInspector.Status st = (mInspector.Status)estado_Prop.enumValueIndex;

        // Sengun el caso del enum
        switch (st)
        {
            case mInspector.Status.Waypoints:
                EditorGUILayout.PropertyField(mTransform_Prop, new GUIContent("Transform"));
                EditorGUILayout.PropertyField(mObj_Prop, new GUIContent("Objeto"));
                EditorGUILayout.IntSlider(slider_Prop, 0, 100, new GUIContent("Slider"));
                break;

            case mInspector.Status.FreePatrol:
                EditorGUILayout.PropertyField(mString_Prop, new GUIContent("String"));
                EditorGUILayout.IntSlider(slider_Prop, 0, 100, new GUIContent("Slider"));
                break;
        }

        // Aplica / Modifica los cambios
        serializedObject.ApplyModifiedProperties();
    }
}
