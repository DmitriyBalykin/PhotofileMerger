using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PhotofileMerger
{
    class Sources : TableLayoutPanel
    {
        private List<SourceControl> sourcesList;

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
        private void refreshSourcesView() { 
            Controls.Clear();
            foreach(Control control in sourcesList){
                Controls.Add(control);
            }
        }
    }
}
