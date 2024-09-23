namespace Sistem_Informasi_Sekolah.Mapel
{
    partial class MapelList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ListDataGrid).BeginInit();
            SuspendLayout();
            // 
            // ListDataGrid
            // 
            ListDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListDataGrid.Location = new Point(0, 0);
            ListDataGrid.Name = "ListDataGrid";
            ListDataGrid.RowTemplate.Height = 25;
            ListDataGrid.Size = new Size(309, 381);
            ListDataGrid.TabIndex = 0;
            // 
            // MapelList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 381);
            Controls.Add(ListDataGrid);
            Name = "MapelList";
            Text = "MapelList";
            ((System.ComponentModel.ISupportInitialize)ListDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ListDataGrid;
    }
}