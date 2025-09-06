namespace Hotkey_Trainer
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            lblCommand = new Label();
            lblCategory = new Label();
            txtGuess = new TextBox();
            lblKeys = new Label();
            lblAnswer = new Label();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(575, 426);
            dataGridView1.TabIndex = 0;
            // 
            // lblCommand
            // 
            lblCommand.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCommand.Location = new Point(593, 64);
            lblCommand.Name = "lblCommand";
            lblCommand.Size = new Size(562, 52);
            lblCommand.TabIndex = 1;
            lblCommand.Text = "-";
            lblCommand.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCategory
            // 
            lblCategory.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(593, 12);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(562, 52);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "-";
            lblCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtGuess
            // 
            txtGuess.Font = new Font("Segoe UI", 24F);
            txtGuess.Location = new Point(593, 119);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(562, 50);
            txtGuess.TabIndex = 3;
            txtGuess.KeyDown += txtGuess_KeyDown;
            txtGuess.KeyUp += txtGuess_KeyUp;
            // 
            // lblKeys
            // 
            lblKeys.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKeys.Location = new Point(593, 172);
            lblKeys.Name = "lblKeys";
            lblKeys.Size = new Size(562, 52);
            lblKeys.TabIndex = 4;
            lblKeys.Text = "-";
            lblKeys.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAnswer
            // 
            lblAnswer.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnswer.Location = new Point(593, 224);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(562, 52);
            lblAnswer.TabIndex = 5;
            lblAnswer.Text = "-";
            lblAnswer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 26F);
            btnNext.Location = new Point(933, 369);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(222, 58);
            btnNext.TabIndex = 6;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 450);
            Controls.Add(btnNext);
            Controls.Add(lblAnswer);
            Controls.Add(lblKeys);
            Controls.Add(txtGuess);
            Controls.Add(lblCategory);
            Controls.Add(lblCommand);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblCommand;
        private Label lblCategory;
        private TextBox txtGuess;
        private Label lblKeys;
        private Label lblAnswer;
        private Button btnNext;
    }
}
