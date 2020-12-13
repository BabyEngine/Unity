using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Linq;

namespace BabyEngine {
    public class LuaUICodeGen : EditorWindow {

        [MenuItem("GameObject/BabyEngine/A-Panel代码生成-更新", priority = -110)]
        public static void PanelCodeGen() {
            if (Selection.gameObjects.Length == 0) {
                return;
            }
            GameObject selectObject = Selection.gameObjects[0];
            string panelName = selectObject.name;

            var datas = GetUIGenAttributes(selectObject.transform);
            GenCode(panelName, datas);
        }
        [MenuItem("GameObject/BabyEngine/B-子节点代码生成-更新", priority = -109)]
        public static void SubPathCodeGen() {
            if (Selection.gameObjects.Length == 0) {
                return;
            }
            GameObject selectObject = Selection.gameObjects[0];
            string panelName = selectObject.name;

            var datas = GetUIGenAttributes(selectObject.transform);
            CopyCode(panelName, datas);
        }

        static Dictionary<UIType, string> codeTemplate = new Dictionary<UIType, string> {
            { UIType.kImage,  "    {{ t=1, p='{0}' }},\n" },
            { UIType.kButton, "    {{ t=2, p='{0}' }},\n" },
            { UIType.kText,   "    {{ t=3, p='{0}' }},\n" },
            { UIType.kSlider, "    {{ t=4, p='{0}' }},\n" },
        };

        private static void CopyCode(string panelName, List<UIGenAttribute> datas) {
            try {
                EditorUtility.ClearProgressBar();
                EditorUtility.DisplayProgressBar("生成代码", "生成中", 0.1f);
                StringBuilder sb = new StringBuilder();
                foreach (var info in datas) {
                    if (codeTemplate.ContainsKey(info.type)) {
                        sb.AppendFormat(codeTemplate[info.type], info.path.Replace(panelName + "/", ""));
                    }
                }
                string lua = "local m = {{ \n{0}}}\n";
                var luaCode = string.Format(lua, sb.ToString());
                GUIUtility.systemCopyBuffer = luaCode;
                EditorUtility.DisplayProgressBar("生成代码", "生成中", 1.0f);
            } finally {
                EditorUtility.ClearProgressBar();
            }
        }
        private static void GenCode(string panelName, List<UIGenAttribute> datas) {
            StringBuilder sb = new StringBuilder();
            foreach (var info in datas) {
                if (codeTemplate.ContainsKey(info.type)) {
                    sb.AppendFormat(codeTemplate[info.type], info.path.Replace(panelName + "/", ""));
                }
            }
            string lua = "local m = {{ \n{0}}}\n" + "return m";
            var luaCode = string.Format(lua, sb.ToString());
            string genToPath = "Assets/Game/lua/panel/";

            string luaFilename = genToPath + panelName + "_AutoBind.lua";
            if (!EditorUtility.DisplayDialog("生成或更新代码", "即将更新到:{0}".Format(luaFilename), "确定", "取消")) {
                return;
            }

            string basePath = Path.GetDirectoryName(luaFilename);
            if (!Directory.Exists(basePath)) {
                Directory.CreateDirectory(basePath);
            }
            File.WriteAllText(luaFilename, luaCode);
            // 如果 XXXPanel.lua文件没有存在, 也顺便创建了
            string panelSrc = @"{0} = PanelBase('panel/{1}', 5) 
local self = {2}
local buttonEventHandler = {{}}
local remapping = {{}}
function self.ctor(cb, parent)
    self.BindUI()
    self.BindButtonHandler(buttonEventHandler)
    self.UIRemapping(self, remapping)
end
function self.onShow()
end
function self.onHide()
end";
            string panelSrcPath = $"{genToPath}{panelName}.lua";
            if (!File.Exists(panelSrcPath)) {
                Debug.Log(panelSrc);
                File.WriteAllText(panelSrcPath, string.Format(panelSrc, panelName, panelName, panelName));
            }

            AssetDatabase.Refresh();
        }

        static List<UIGenAttribute> GetUIGenAttributes(Transform tras, string path = "") {
            List<UIGenAttribute> result = new List<UIGenAttribute>();
            path += tras.gameObject.name + "/";
            foreach (Transform tra in tras) {
                result.AddRange(GetUIGenAttributes(tra, path));
                UIGenAttribute info = null;
                if (tra.name.StartsWith("Image_")) {
                    info = new UIGenAttribute();
                    info.type = UIType.kImage;

                } else if (tra.name.StartsWith("Button_")) {
                    info = new UIGenAttribute();
                    info.type = UIType.kButton;
                } else if (tra.name.StartsWith("Text_")) {
                    info = new UIGenAttribute();
                    info.type = UIType.kText;
                } else if (tra.name.StartsWith("Slider_")) {
                    info = new UIGenAttribute();
                    info.type = UIType.kSlider;
                }
                if (info != null) {
                    info.path = path + tra.gameObject.name;
                    info.gameObject = tra.gameObject;
                    result.Add(info);
                }
            }
            result = result.OrderBy(o => o.path).ToList();
            return result;
        }
    }

    class UIGenAttribute {
        public UIType type;
        public GameObject gameObject;
        public string path;
    }

    enum UIType {
        kImage,
        kButton,
        kText,
        kSlider,
    }

    
}