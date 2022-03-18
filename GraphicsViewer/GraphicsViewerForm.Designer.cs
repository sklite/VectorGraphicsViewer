using System.Windows.Forms;

namespace GraphicsViewer
{
    partial class GraphicsViewerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnMain = new System.Windows.Forms.Panel();
            this.lbZoom = new System.Windows.Forms.Label();
            this.btImportFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.White;
            this.pnMain.Location = new System.Drawing.Point(12, 12);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(600, 600);
            this.pnMain.TabIndex = 0;
            this.pnMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnMain_MouseClick);
            // 
            // lbZoom
            // 
            this.lbZoom.AutoSize = true;
            this.lbZoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbZoom.Location = new System.Drawing.Point(616, 85);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(134, 20);
            this.lbZoom.TabIndex = 1;
            this.lbZoom.Text = "Zoom level: 100%";
            // 
            // btImportFile
            // 
            this.btImportFile.Location = new System.Drawing.Point(616, 12);
            this.btImportFile.Name = "btImportFile";
            this.btImportFile.Size = new System.Drawing.Size(138, 57);
            this.btImportFile.TabIndex = 2;
            this.btImportFile.Text = "Import file";
            this.btImportFile.UseVisualStyleBackColor = true;
            this.btImportFile.Click += new System.EventHandler(this.btImportFile_Click);
            // 
            // GraphicsViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 618);
            this.Controls.Add(this.btImportFile);
            this.Controls.Add(this.lbZoom);
            this.Controls.Add(this.pnMain);
            this.Name = "GraphicsViewerForm";
            this.Text = "Simple vector graphic viewer";
            this.Load += new System.EventHandler(this.GraphicsViewerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnMain;
        private Label lbZoom;
        private Button btImportFile;
    }
}
