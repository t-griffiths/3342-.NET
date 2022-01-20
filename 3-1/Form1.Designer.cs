namespace Griffiths_CalculateLetterGrade
{
    partial class frmCalculateGrade
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtboxLetterGrade = new System.Windows.Forms.TextBox();
            this.txtNumGrade = new System.Windows.Forms.TextBox();
            this.lblLetter = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "index2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnCalculate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalculate.Location = new System.Drawing.Point(15, 79);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(104, 32);
            this.btnCalculate.TabIndex = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.index2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnExit
            // 
            this.btnExit.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "index3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(125, 79);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 32);
            this.btnExit.TabIndex = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.index3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtboxLetterGrade
            // 
            this.txtboxLetterGrade.DataBindings.Add(new System.Windows.Forms.Binding("TabStop", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "tabstopfalse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtboxLetterGrade.Location = new System.Drawing.Point(119, 39);
            this.txtboxLetterGrade.Name = "txtboxLetterGrade";
            this.txtboxLetterGrade.ReadOnly = true;
            this.txtboxLetterGrade.Size = new System.Drawing.Size(98, 20);
            this.txtboxLetterGrade.TabIndex = 5;
            this.txtboxLetterGrade.TabStop = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.tabstopfalse;
            // 
            // txtNumGrade
            // 
            this.txtNumGrade.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "index2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtNumGrade.Location = new System.Drawing.Point(119, 9);
            this.txtNumGrade.Name = "txtNumGrade";
            this.txtNumGrade.Size = new System.Drawing.Size(98, 20);
            this.txtNumGrade.TabIndex = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.index2;
            // 
            // lblLetter
            // 
            this.lblLetter.AutoSize = true;
            this.lblLetter.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "index3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblLetter.Location = new System.Drawing.Point(12, 46);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(69, 13);
            this.lblLetter.TabIndex = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.index3;
            this.lblLetter.Text = "Letter Grade:";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.DataBindings.Add(new System.Windows.Forms.Binding("TextAlign", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "MiddleLeft", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelNum.DataBindings.Add(new System.Windows.Forms.Binding("TabIndex", global::Griffiths_CalculateLetterGrade.Properties.Settings.Default, "TabIndex0", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelNum.Location = new System.Drawing.Point(12, 9);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(79, 13);
            this.labelNum.TabIndex = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.TabIndex0;
            this.labelNum.Text = "Number Grade:";
            this.labelNum.TextAlign = global::Griffiths_CalculateLetterGrade.Properties.Settings.Default.MiddleLeft;
            // 
            // frmCalculateGrade
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(304, 135);
            this.Controls.Add(this.txtboxLetterGrade);
            this.Controls.Add(this.txtNumGrade);
            this.Controls.Add(this.lblLetter);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalculate);
            this.Name = "frmCalculateGrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculate Letter Grade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.TextBox txtNumGrade;
        private System.Windows.Forms.TextBox txtboxLetterGrade;
    }
}

