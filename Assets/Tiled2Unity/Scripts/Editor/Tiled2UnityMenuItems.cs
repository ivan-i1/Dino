using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

namespace Tiled2Unity
{
    class Tiled2UnityMenuItems
    {
        // Convenience function for packaging this library
        [MenuItem("Tiled2Unity/Export Tiled2Unity Library ...")]
        static void ExportLibrary()
        {
            string name = String.Format("Tiled2Unity.{0}.unitypackage", ImportTiled2Unity.ThisVersion);
            var path = EditorUtility.SaveFilePanel("Save texture as PNG", "", name, "unitypackage");
            if (path.Length != 0)
            {
                List<string> packageFiles = new List<string>();
                packageFiles.AddRange(EnumerateAssetFilesAt("Assets/Tiled2Unity", ".cs", ".shader", ".txt"));
                AssetDatabase.ExportPackage(packageFiles.ToArray(), path);
            }
        }

        private static IEnumerable<string> EnumerateAssetFilesAt(string dir, params string[] extensions)
        {
            foreach (string d in Directory.GetDirectories(dir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    if (extensions.Any(ext => String.Compare(ext, Path.GetExtension(f), true) == 0))
                    {
                        yield return f;
                    }
                }

                foreach (string f in EnumerateAssetFilesAt(d, extensions))
                {
                    yield return f;
                }
            }
        }


    }
}
