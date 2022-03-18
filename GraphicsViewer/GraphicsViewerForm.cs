using System;
using System.IO;
using System.Windows.Forms;
using GraphicsViewer.Core;
using GraphicsViewer.Core.Events;

namespace GraphicsViewer
{
    public partial class GraphicsViewerForm : Form, IVectorGraphicView
    {
        public GraphicsViewerForm()
        {
            InitializeComponent();
        }

        private void btImportFile_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SampleData");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileImported?.Invoke(this, new ImportFileEventArgs(ofd.FileName));
            }
        }

        private void GraphicsViewerForm_Load(object sender, EventArgs e)
        {
            GraphicsInitialized?.Invoke(this, new GraphicsInitializedEventArgs(pnMain.CreateGraphics()));
        }

        private void pnMain_MouseClick(object sender, MouseEventArgs e)
        {
            PanelClicked?.Invoke(this, e);
        }

        public void SetBusy(bool isBusy)
        {
            btImportFile.Enabled = !isBusy;
            btImportFile.Text = isBusy ? "Importing file" : "Import file";
        }

        public void UpdateZoom(int zoomPercentage)
        {
            lbZoom.Text = $"Zoom level: {zoomPercentage}%";
        }

        public event EventHandler<ImportFileEventArgs>? FileImported;
        public event EventHandler<GraphicsInitializedEventArgs>? GraphicsInitialized;
        public event EventHandler<EventArgs>? PanelClicked;
    }
}
