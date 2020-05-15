using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateFont : EditorWindow {
    [MenuItem("Tools/创建字体(sprite)")]
    public static void Open() {
        GetWindow<CreateFont>("创建字体");
    }

    private Texture2D tex;
    private string fontName;
    private string fontPath;

    private void OnGUI() {
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("字体图片：");
        tex = (Texture2D)EditorGUILayout.ObjectField(tex, typeof(Texture2D), true);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("字体名称：");
        fontName = EditorGUILayout.TextField(fontName);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(string.IsNullOrEmpty(fontPath) ? "选择路径" : fontPath)) {
            fontPath = EditorUtility.OpenFolderPanel("字体路径", Application.dataPath, "");
            if (string.IsNullOrEmpty(fontPath)) {
                Debug.Log("取消选择路径");
            } else {
                fontPath = fontPath.Replace(Application.dataPath, "") + "/";
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("创建")) {
            Create();
        }
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
    }

    private void Create() {
        if (tex == null) {
            Debug.LogWarning("创建失败，图片为空！");
            return;
        }

        if (string.IsNullOrEmpty(fontPath)) {
            Debug.LogWarning("字体路径为空！");
            return;
        }
        if (fontName == null) {
            Debug.LogWarning("创建失败，字体名称为空！");
            return;
        } else {
            if (File.Exists(Application.dataPath + fontPath + fontName + ".fontsettings")) {
                Debug.LogError("创建失败，已存在同名字体文件");
                return;
            }
            if (File.Exists(Application.dataPath + fontPath + fontName + ".mat")) {
                Debug.LogError("创建失败，已存在同名字体材质文件");
                return;
            }
        }

        string selectionPath = AssetDatabase.GetAssetPath(tex);
        //if (selectionPath.Contains("/Resources/")) {
        
            string selectionExt = Path.GetExtension(selectionPath);
            if (selectionExt.Length == 0) {
                Debug.LogError("创建失败！");
                return;
            }

            string fontPathName = fontPath + fontName + ".fontsettings";
            string matPathName = fontPath + fontName + ".mat";
            float lineSpace = 0.1f;
            //string loadPath = selectionPath.Remove(selectionPath.Length - selectionExt.Length).Replace("Assets/Resources/", "");
            string loadPath = selectionPath.Replace(selectionExt, "").Substring(selectionPath.IndexOf("/Resources/") + "/Resources/".Length);
            Sprite[] sprites = Resources.LoadAll<Sprite>(loadPath);
            Debug.Log("loadPath:" + loadPath);
            //Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(loadPath) as Sprite[];
            if (sprites != null && sprites.Length > 0) {
                Material mat = new Material(Shader.Find("GUI/Text Shader"));
                mat.SetTexture("_MainTex", tex);
                Font m_myFont = new Font();
                m_myFont.material = mat;
                CharacterInfo[] characterInfo = new CharacterInfo[sprites.Length];
                for (int i = 0; i < sprites.Length; i++) {
                    if (sprites[i].rect.height > lineSpace) {
                        lineSpace = sprites[i].rect.height;
                    }
                }
                for (int i = 0; i < sprites.Length; i++) {
                    Sprite spr = sprites[i];
                    CharacterInfo info = new CharacterInfo();
                    try {
                        //info.index = System.Convert.ToInt32(spr.name) + 48;
                        char chr;
                        if (char.TryParse(spr.name, out chr)) {
                            info.index = chr;
                        }
                    } catch {
                        Debug.LogError("创建失败，Sprite名称错误！");
                        return;
                    }
                    Rect rect = spr.rect;
                    float pivot = spr.pivot.y / rect.height - 0.5f;
                    if (pivot > 0) {
                        pivot = -lineSpace / 2 - spr.pivot.y;
                    } else if (pivot < 0) {
                        pivot = -lineSpace / 2 + rect.height - spr.pivot.y;
                    } else {
                        pivot = -lineSpace / 2;
                    }
                    int offsetY = (int)(pivot + (lineSpace - rect.height) / 2);
                    info.uvBottomLeft = new Vector2((float)rect.x / tex.width, (float)(rect.y) / tex.height);
                    info.uvBottomRight = new Vector2((float)(rect.x + rect.width) / tex.width, (float)(rect.y) / tex.height);
                    info.uvTopLeft = new Vector2((float)rect.x / tex.width, (float)(rect.y + rect.height) / tex.height);
                    info.uvTopRight = new Vector2((float)(rect.x + rect.width) / tex.width, (float)(rect.y + rect.height) / tex.height);
                    info.minX = 0;
                    info.minY = -(int)rect.height - offsetY;
                    info.maxX = (int)rect.width;
                    info.maxY = -offsetY;
                    info.advance = (int)rect.width;
                    characterInfo[i] = info;
                }
                AssetDatabase.CreateAsset(mat, "Assets" + matPathName);
                AssetDatabase.CreateAsset(m_myFont, "Assets" + fontPathName);
                m_myFont.characterInfo = characterInfo;
                EditorUtility.SetDirty(m_myFont);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();//刷新资源
                Debug.Log("创建字体成功");

            } else {
                Debug.LogError("图集错误！");
            }
        
    }
}