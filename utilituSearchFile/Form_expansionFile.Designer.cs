namespace utilituSearchFile
{
    partial class Form_expansionFile
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
            this.panel_arrExpansionFile = new System.Windows.Forms.Panel();
            this.button_saveForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_allClickExpanxion = new System.Windows.Forms.Button();
            this.button_notSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_arrExpansionFile
            // 
            this.panel_arrExpansionFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_arrExpansionFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel_arrExpansionFile.Location = new System.Drawing.Point(29, 51);
            this.panel_arrExpansionFile.Name = "panel_arrExpansionFile";
            this.panel_arrExpansionFile.Size = new System.Drawing.Size(338, 207);
            this.panel_arrExpansionFile.TabIndex = 0;
            // 
            // button_saveForm
            // 
            this.button_saveForm.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_saveForm.Location = new System.Drawing.Point(258, 271);
            this.button_saveForm.Name = "button_saveForm";
            this.button_saveForm.Size = new System.Drawing.Size(125, 41);
            this.button_saveForm.TabIndex = 1;
            this.button_saveForm.Text = "Сохранить";
            this.button_saveForm.UseVisualStyleBackColor = true;
            this.button_saveForm.Click += new System.EventHandler(this.button_saveForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор расширений файлов для поиска";
            // 
            // button_allClickExpanxion
            // 
            this.button_allClickExpanxion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_allClickExpanxion.Location = new System.Drawing.Point(14, 272);
            this.button_allClickExpanxion.Name = "button_allClickExpanxion";
            this.button_allClickExpanxion.Size = new System.Drawing.Size(110, 41);
            this.button_allClickExpanxion.TabIndex = 3;
            this.button_allClickExpanxion.Text = "Выбрать все";
            this.button_allClickExpanxion.UseVisualStyleBackColor = true;
            this.button_allClickExpanxion.Click += new System.EventHandler(this.button_allClickExpanxion_Click);
            // 
            // button_notSave
            // 
            this.button_notSave.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_notSave.Location = new System.Drawing.Point(134, 271);
            this.button_notSave.Name = "button_notSave";
            this.button_notSave.Size = new System.Drawing.Size(111, 42);
            this.button_notSave.TabIndex = 4;
            this.button_notSave.Text = "Отмена";
            this.button_notSave.UseVisualStyleBackColor = true;
            this.button_notSave.Click += new System.EventHandler(this.button_notSave_Click);
            // 
            // Form_expansionFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 326);
            this.Controls.Add(this.button_saveForm);
            this.Controls.Add(this.button_notSave);
            this.Controls.Add(this.button_allClickExpanxion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_arrExpansionFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(413, 373);
            this.MinimumSize = new System.Drawing.Size(413, 373);
            this.Name = "Form_expansionFile";
            this.Text = "Выбор расширений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_expansionFile_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_arrExpansionFile;
        private System.Windows.Forms.Button button_saveForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_allClickExpanxion;
        private System.Windows.Forms.Button button_notSave;
    }
}