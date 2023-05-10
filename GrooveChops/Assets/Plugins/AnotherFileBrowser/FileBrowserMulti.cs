#if UNITY_STANDALONE_WIN
using Ookii.Dialogs;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AnotherFileBrowser.Windows
{
    public class FileBrowserMulti
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetActiveWindow();

        public FileBrowserMulti() { }

        /// <summary>
        /// FileDialog for picking a single file
        /// </summary>
        /// <param name="browserProperties">Special Properties of File Dialog</param>
        /// <param name="filepaths">User picked path (Callback)</param>
        public void OpenFileBrowser(BrowserProperties browserProperties, Action<string[]> filepaths)
        {
            var ofd = new VistaOpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = browserProperties.title == null ? "Select a File" : browserProperties.title;
            ofd.InitialDirectory = browserProperties.initialDir == null ? @"C:\" : browserProperties.initialDir;
            ofd.Filter = browserProperties.filter == null ? "All files (*.*)|*.*" : browserProperties.filter;
            ofd.FilterIndex = browserProperties.filterIndex + 1;
            ofd.RestoreDirectory = browserProperties.restoreDirectory;

            if (ofd.ShowDialog(new WindowWrapper(GetActiveWindow())) == DialogResult.OK)
            {
                filepaths(ofd.FileNames);
            }
        }


    }
}
#endif