using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MyEnum))]
public class MyEnumDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Enumの値を取得
        MyEnum enumValue = (MyEnum)property.enumValueIndex;

        // Enumの値に応じてInspectorの表示を変更
        switch (enumValue)
        {
            case MyEnum.Option1:
                EditorGUI.PropertyField(position, property, label);
                break;
            case MyEnum.Option2:
                EditorGUI.HelpBox(position, "Option 2 is selected!", MessageType.Info);
                break;
            case MyEnum.Option3:
                EditorGUILayout.Space();
                EditorGUI.LabelField(position, label.text, "Option 3 is selected!");
                break;
        }
    }
}
