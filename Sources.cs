using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PhotofileMerger
{
    class Sources : Panel
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        TableLayoutPanel internalLayout;

        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }

        private List<SourceControl> sourcesList = new List<SourceControl>();

        public Sources()
            : base()
        {
            initializeLayout();
        }

        public void AddSource(SourceControl source) {
            sourcesList.Add(source);
            refreshSourcesView();
        }
        public void RemoveSource(SourceControl source) {
            sourcesList.Remove(source);
            refreshSourcesView();
        }
        public int SourcesCount() {
            return sourcesList.Count;
        }
        public Dictionary<string, TimeSpan> GetSourcesTimeMap() {
            Dictionary<string, TimeSpan> dict = new Dictionary<string, TimeSpan>();
            foreach(SourceControl sc in sourcesList){
                dict.Add(sc.GetRootFolder(), sc.GetTimeShift());
            }

            return dict;
        }
        private void refreshSourcesView() {
            internalLayout.Controls.Clear();
            internalLayout.Controls.AddRange(sourcesList.ToArray());
            //ShowScrollBar(Handle, (int)ScrollBarDirection.SB_HORZ, false);
        }
        private void initializeLayout() {
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            
            Dock = DockStyle.Top;
            AutoScroll = true;
            MaximumSize = new System.Drawing.Size(0, 400);

            internalLayout = new TableLayoutPanel();
            internalLayout.AutoSize = true;
            internalLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            internalLayout.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            internalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            internalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            //internalLayout.Dock = DockStyle.Fill;

            Controls.Add(internalLayout);
        }
    }
}
