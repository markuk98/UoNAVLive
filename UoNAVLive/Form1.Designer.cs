namespace UoNAVLive
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBoxSearchBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DGVUoNDevices = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonAddDevice = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonANDSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUoNDevices)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearchBox
            // 
            this.textBoxSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchBox.Location = new System.Drawing.Point(12, 12);
            this.textBoxSearchBox.Name = "textBoxSearchBox";
            this.textBoxSearchBox.Size = new System.Drawing.Size(410, 29);
            this.textBoxSearchBox.TabIndex = 0;
            this.textBoxSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DGVUoNDevices
            // 
            this.DGVUoNDevices.AllowUserToAddRows = false;
            this.DGVUoNDevices.AllowUserToDeleteRows = false;
            this.DGVUoNDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUoNDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVUoNDevices.Location = new System.Drawing.Point(0, 0);
            this.DGVUoNDevices.Name = "DGVUoNDevices";
            this.DGVUoNDevices.Size = new System.Drawing.Size(1446, 497);
            this.DGVUoNDevices.TabIndex = 2;
            this.DGVUoNDevices.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUoNDevices_CellEndEdit);
            this.DGVUoNDevices.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUoNDevices_CellValidated);
            this.DGVUoNDevices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGVUoNDevices_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonANDSearch);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.buttonAddDevice);
            this.panel1.Controls.Add(this.textBoxSearchBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1446, 52);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(852, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Show Devices with mis-matched IP\'s";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(496, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(80, 29);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.TextSearch);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Location = new System.Drawing.Point(656, 12);
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Size = new System.Drawing.Size(79, 29);
            this.buttonAddDevice.TabIndex = 1;
            this.buttonAddDevice.Text = "Add Device";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVUoNDevices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1446, 497);
            this.panel2.TabIndex = 4;
            // 
            // buttonANDSearch
            // 
            this.buttonANDSearch.Location = new System.Drawing.Point(428, 12);
            this.buttonANDSearch.Name = "buttonANDSearch";
            this.buttonANDSearch.Size = new System.Drawing.Size(51, 29);
            this.buttonANDSearch.TabIndex = 4;
            this.buttonANDSearch.Text = "AND";
            this.buttonANDSearch.UseVisualStyleBackColor = true;
            this.buttonANDSearch.Click += new System.EventHandler(this.buttonANDSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 549);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUoNDevices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView DGVUoNDevices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddDevice;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonANDSearch;
    }
}

