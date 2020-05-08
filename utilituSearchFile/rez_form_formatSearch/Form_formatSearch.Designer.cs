namespace utilituSearchFile
{
    partial class Form_formatSearch
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
            this.button_notSave = new System.Windows.Forms.Button();
            this.button_saveForm = new System.Windows.Forms.Button();
            this.panel_arrFormatSearch = new System.Windows.Forms.Panel();
            this.panel_formatFile = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_formatDir = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_allClickExpanxion = new System.Windows.Forms.Button();
            this.panel_arrFormatSearch.SuspendLayout();
            this.panel_formatFile.SuspendLayout();
            this.panel_formatDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_notSave
            // 
            this.button_notSave.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_notSave.Location = new System.Drawing.Point(136, 269);
            this.button_notSave.Name = "button_notSave";
            this.button_notSave.Size = new System.Drawing.Size(111, 42);
            this.button_notSave.TabIndex = 5;
            this.button_notSave.Text = "Отмена";
            this.button_notSave.UseVisualStyleBackColor = true;
            this.button_notSave.Click += new System.EventHandler(this.button_notSave_Click);
            // 
            // button_saveForm
            // 
            this.button_saveForm.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_saveForm.Location = new System.Drawing.Point(257, 268);
            this.button_saveForm.Name = "button_saveForm";
            this.button_saveForm.Size = new System.Drawing.Size(125, 41);
            this.button_saveForm.TabIndex = 6;
            this.button_saveForm.Text = "Сохранить";
            this.button_saveForm.UseVisualStyleBackColor = true;
            this.button_saveForm.Click += new System.EventHandler(this.button_saveForm_Click);
            // 
            // panel_arrFormatSearch
            // 
            this.panel_arrFormatSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_arrFormatSearch.Controls.Add(this.panel_formatFile);
            this.panel_arrFormatSearch.Controls.Add(this.panel_formatDir);
            this.panel_arrFormatSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_arrFormatSearch.Location = new System.Drawing.Point(22, 36);
            this.panel_arrFormatSearch.Name = "panel_arrFormatSearch";
            this.panel_arrFormatSearch.Size = new System.Drawing.Size(338, 207);
            this.panel_arrFormatSearch.TabIndex = 7;
            // 
            // panel_formatFile
            // 
            this.panel_formatFile.Controls.Add(this.label2);
            this.panel_formatFile.Location = new System.Drawing.Point(165, -2);
            this.panel_formatFile.Name = "panel_formatFile";
            this.panel_formatFile.Size = new System.Drawing.Size(171, 202);
            this.panel_formatFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Поиск ... файлов";
            // 
            // panel_formatDir
            // 
            this.panel_formatDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_formatDir.Controls.Add(this.label3);
            this.panel_formatDir.Location = new System.Drawing.Point(-2, -2);
            this.panel_formatDir.Name = "panel_formatDir";
            this.panel_formatDir.Size = new System.Drawing.Size(164, 202);
            this.panel_formatDir.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Поиск в ... каталогах";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(65, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выбор формата поиска файлов";
            // 
            // button_allClickExpanxion
            // 
            this.button_allClickExpanxion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_allClickExpanxion.Location = new System.Drawing.Point(12, 269);
            this.button_allClickExpanxion.Name = "button_allClickExpanxion";
            this.button_allClickExpanxion.Size = new System.Drawing.Size(110, 41);
            this.button_allClickExpanxion.TabIndex = 9;
            this.button_allClickExpanxion.Text = "Выбрать все";
            this.button_allClickExpanxion.UseVisualStyleBackColor = true;
            this.button_allClickExpanxion.Click += new System.EventHandler(this.button_allClickExpanxion_Click);
            // 
            // Form_formatSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 326);
            this.Controls.Add(this.button_allClickExpanxion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_arrFormatSearch);
            this.Controls.Add(this.button_saveForm);
            this.Controls.Add(this.button_notSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(413, 373);
            this.MinimumSize = new System.Drawing.Size(413, 373);
            this.Name = "Form_formatSearch";
            this.Text = "Форматы поиска ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_formatSearch_FormClosing);
            this.panel_arrFormatSearch.ResumeLayout(false);
            this.panel_formatFile.ResumeLayout(false);
            this.panel_formatFile.PerformLayout();
            this.panel_formatDir.ResumeLayout(false);
            this.panel_formatDir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_notSave;
        private System.Windows.Forms.Button button_saveForm;
        private System.Windows.Forms.Panel panel_arrFormatSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_formatDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_allClickExpanxion;
        private System.Windows.Forms.Panel panel_formatFile;
    }
}