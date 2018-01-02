namespace Salary.form
{
    partial class WatchSalary
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
            this.label1 = new System.Windows.Forms.Label();
            this.basicSalaryLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.allowanceLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.totalSalaryLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ReasonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargebackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(100, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "基本工资";
            // 
            // basicSalaryLabel
            // 
            this.basicSalaryLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.basicSalaryLabel.Location = new System.Drawing.Point(220, 140);
            this.basicSalaryLabel.Name = "basicSalaryLabel";
            this.basicSalaryLabel.Size = new System.Drawing.Size(100, 23);
            this.basicSalaryLabel.TabIndex = 1;
            this.basicSalaryLabel.Text = "工资";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(100, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "岗位津贴";
            // 
            // allowanceLabel
            // 
            this.allowanceLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.allowanceLabel.Location = new System.Drawing.Point(220, 196);
            this.allowanceLabel.Name = "allowanceLabel";
            this.allowanceLabel.Size = new System.Drawing.Size(100, 23);
            this.allowanceLabel.TabIndex = 3;
            this.allowanceLabel.Text = "津贴";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.Location = new System.Drawing.Point(100, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "员工姓名";
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.nameLabel.Location = new System.Drawing.Point(220, 72);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(100, 23);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "姓名";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label7.Location = new System.Drawing.Point(255, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 36);
            this.label7.TabIndex = 6;
            this.label7.Text = "合计工资";
            // 
            // totalSalaryLabel
            // 
            this.totalSalaryLabel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.totalSalaryLabel.Location = new System.Drawing.Point(378, 284);
            this.totalSalaryLabel.Name = "totalSalaryLabel";
            this.totalSalaryLabel.Size = new System.Drawing.Size(72, 23);
            this.totalSalaryLabel.TabIndex = 7;
            this.totalSalaryLabel.Text = "工资";
            // 
            // dataGridView
            // 
            this.dataGridView.CausesValidation = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReasonCol,
            this.ChargebackCol});
            this.dataGridView.Location = new System.Drawing.Point(383, 72);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 27;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(300, 147);
            this.dataGridView.TabIndex = 8;
            // 
            // ReasonCol
            // 
            this.ReasonCol.HeaderText = "扣款原因";
            this.ReasonCol.Name = "ReasonCol";
            this.ReasonCol.ReadOnly = true;
            // 
            // ChargebackCol
            // 
            this.ChargebackCol.HeaderText = "扣款金额";
            this.ChargebackCol.Name = "ChargebackCol";
            this.ChargebackCol.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1.Location = new System.Drawing.Point(269, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Confirm);
            // 
            // WatchSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.totalSalaryLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.allowanceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.basicSalaryLabel);
            this.Controls.Add(this.label1);
            this.Name = "WatchSalary";
            this.Text = "WatchSalary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label basicSalaryLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label allowanceLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label totalSalaryLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargebackCol;
        private System.Windows.Forms.Button button1;
    }
}