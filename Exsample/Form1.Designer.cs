using System.Collections.Generic;
using System.Windows.Forms;

namespace Example
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
            this.labelNumVertices = new System.Windows.Forms.Label();
            this.labelNumColors = new System.Windows.Forms.Label();
            this.labelColoringMethod = new System.Windows.Forms.Label();
            this.buttonColorGraph = new System.Windows.Forms.Button();
            this.labelAdjacencyMatrix = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxVertix = new System.Windows.Forms.ComboBox();
            this.comboBoxColorNum = new System.Windows.Forms.ComboBox();
            this.comboBoxColoringMethod = new System.Windows.Forms.ComboBox();
            this.generateMatrix = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonClearMatrix = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.buttonexit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumVertices
            // 
            this.labelNumVertices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumVertices.AutoSize = true;
            this.labelNumVertices.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumVertices.Location = new System.Drawing.Point(858, 12);
            this.labelNumVertices.Name = "labelNumVertices";
            this.labelNumVertices.Size = new System.Drawing.Size(189, 29);
            this.labelNumVertices.TabIndex = 2;
            this.labelNumVertices.Text = "Кількість вершин:";
            this.labelNumVertices.Click += new System.EventHandler(this.labelNumVertices_Click);
            // 
            // labelNumColors
            // 
            this.labelNumColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumColors.AutoSize = true;
            this.labelNumColors.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNumColors.Location = new System.Drawing.Point(858, 98);
            this.labelNumColors.Name = "labelNumColors";
            this.labelNumColors.Size = new System.Drawing.Size(314, 29);
            this.labelNumColors.TabIndex = 4;
            this.labelNumColors.Text = "Кількість доступних кольорів:";
            // 
            // labelColoringMethod
            // 
            this.labelColoringMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelColoringMethod.AutoSize = true;
            this.labelColoringMethod.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelColoringMethod.Location = new System.Drawing.Point(861, 425);
            this.labelColoringMethod.Name = "labelColoringMethod";
            this.labelColoringMethod.Size = new System.Drawing.Size(262, 29);
            this.labelColoringMethod.TabIndex = 7;
            this.labelColoringMethod.Text = "Метод розфарбовування:";
            // 
            // buttonColorGraph
            // 
            this.buttonColorGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColorGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonColorGraph.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonColorGraph.Location = new System.Drawing.Point(866, 569);
            this.buttonColorGraph.Name = "buttonColorGraph";
            this.buttonColorGraph.Size = new System.Drawing.Size(167, 29);
            this.buttonColorGraph.TabIndex = 8;
            this.buttonColorGraph.Text = "Розфарбувати граф";
            this.buttonColorGraph.UseVisualStyleBackColor = true;
            this.buttonColorGraph.Click += new System.EventHandler(this.buttonColorGraph_Click);
            // 
            // labelAdjacencyMatrix
            // 
            this.labelAdjacencyMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdjacencyMatrix.AutoSize = true;
            this.labelAdjacencyMatrix.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAdjacencyMatrix.Location = new System.Drawing.Point(861, 191);
            this.labelAdjacencyMatrix.Name = "labelAdjacencyMatrix";
            this.labelAdjacencyMatrix.Size = new System.Drawing.Size(221, 29);
            this.labelAdjacencyMatrix.TabIndex = 10;
            this.labelAdjacencyMatrix.Text = "Матриця суміжності:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(866, 236);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(167, 164);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBoxVertix
            // 
            this.comboBoxVertix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVertix.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxVertix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVertix.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxVertix.FormattingEnabled = true;
            this.comboBoxVertix.Location = new System.Drawing.Point(863, 55);
            this.comboBoxVertix.Name = "comboBoxVertix";
            this.comboBoxVertix.Size = new System.Drawing.Size(167, 29);
            this.comboBoxVertix.TabIndex = 13;
            this.comboBoxVertix.SelectedIndexChanged += new System.EventHandler(this.comboBoxVertix_SelectedIndexChanged);
            // 
            // comboBoxColorNum
            // 
            this.comboBoxColorNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColorNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxColorNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorNum.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxColorNum.FormattingEnabled = true;
            this.comboBoxColorNum.Location = new System.Drawing.Point(863, 142);
            this.comboBoxColorNum.Name = "comboBoxColorNum";
            this.comboBoxColorNum.Size = new System.Drawing.Size(167, 29);
            this.comboBoxColorNum.TabIndex = 14;
            this.comboBoxColorNum.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorNum_SelectedIndexChanged);
            // 
            // comboBoxColoringMethod
            // 
            this.comboBoxColoringMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxColoringMethod.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBoxColoringMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColoringMethod.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxColoringMethod.FormattingEnabled = true;
            this.comboBoxColoringMethod.Location = new System.Drawing.Point(866, 472);
            this.comboBoxColoringMethod.Name = "comboBoxColoringMethod";
            this.comboBoxColoringMethod.Size = new System.Drawing.Size(167, 29);
            this.comboBoxColoringMethod.TabIndex = 15;
            this.comboBoxColoringMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxColoringMethod_SelectedIndexChanged);
            // 
            // generateMatrix
            // 
            this.generateMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateMatrix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generateMatrix.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateMatrix.Location = new System.Drawing.Point(866, 522);
            this.generateMatrix.Name = "generateMatrix";
            this.generateMatrix.Size = new System.Drawing.Size(167, 29);
            this.generateMatrix.TabIndex = 16;
            this.generateMatrix.Text = "Генерація";
            this.generateMatrix.UseVisualStyleBackColor = true;
            this.generateMatrix.Click += new System.EventHandler(this.generateMatrix_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFile.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFile.Location = new System.Drawing.Point(866, 664);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(167, 29);
            this.buttonFile.TabIndex = 17;
            this.buttonFile.Text = "Записати у файл";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Visible = false;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonClearMatrix
            // 
            this.buttonClearMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearMatrix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearMatrix.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearMatrix.Location = new System.Drawing.Point(866, 616);
            this.buttonClearMatrix.Name = "buttonClearMatrix";
            this.buttonClearMatrix.Size = new System.Drawing.Size(167, 29);
            this.buttonClearMatrix.TabIndex = 18;
            this.buttonClearMatrix.Text = "Очистити";
            this.buttonClearMatrix.UseVisualStyleBackColor = true;
            this.buttonClearMatrix.Click += new System.EventHandler(this.buttonClearMatrix_Click);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGraph.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBoxGraph.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(834, 737);
            this.pictureBoxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGraph.TabIndex = 19;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Click += new System.EventHandler(this.pictureBoxGraph_Click_1);
            // 
            // buttonexit
            // 
            this.buttonexit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonexit.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonexit.Location = new System.Drawing.Point(1005, 720);
            this.buttonexit.Name = "buttonexit";
            this.buttonexit.Size = new System.Drawing.Size(167, 29);
            this.buttonexit.TabIndex = 21;
            this.buttonexit.Text = "Вийти";
            this.buttonexit.UseVisualStyleBackColor = true;
            this.buttonexit.Click += new System.EventHandler(this.buttonexit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.buttonexit);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.buttonClearMatrix);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.generateMatrix);
            this.Controls.Add(this.comboBoxColoringMethod);
            this.Controls.Add(this.comboBoxColorNum);
            this.Controls.Add(this.comboBoxVertix);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelAdjacencyMatrix);
            this.Controls.Add(this.buttonColorGraph);
            this.Controls.Add(this.labelColoringMethod);
            this.Controls.Add(this.labelNumColors);
            this.Controls.Add(this.labelNumVertices);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label labelNumVertices;
        private System.Windows.Forms.Label labelNumColors;
        private System.Windows.Forms.Label labelColoringMethod;
        private System.Windows.Forms.Button buttonColorGraph;
        private System.Windows.Forms.Label labelAdjacencyMatrix;
        private DataGridView dataGridView1;
        private ComboBox comboBoxVertix;
        private ComboBox comboBoxColorNum;
        private ComboBox comboBoxColoringMethod;
        private Button generateMatrix;
        private Button buttonFile;
        private Button buttonClearMatrix;
        private PictureBox pictureBoxGraph;
        private Button buttonexit;
    }
}

