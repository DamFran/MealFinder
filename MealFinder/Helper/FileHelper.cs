using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace MealFinder.Helper
{
    public static class FileHelper
    {
        public static void EnsureImagesCopied()
        {
            // PATH EXE (bin/Debug)
            string outputDir = Application.StartupPath;

            // PATH PROJECT ROOT (FIX)
            string projectRoot = Directory.GetParent(
                AppDomain.CurrentDomain.BaseDirectory
            ).Parent.Parent.FullName;

            string sourceDir = Path.Combine(projectRoot, "images");
            string targetDir = Path.Combine(outputDir, "images");


            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(
                    targetDir,
                    Path.GetFileName(file)
                );

                File.Copy(file, destFile, true); // overwrite
            }
        }
    }
}
