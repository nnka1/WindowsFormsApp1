namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.войти = new System.Windows.Forms.Button();
            this.логинBox = new System.Windows.Forms.TextBox();
            this.парольBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // войти
            // 
            this.войти.Font = new System.Drawing.Font("Dubai", 16.2F);
            this.войти.Location = new System.Drawing.Point(431, 337);
            this.войти.Name = "войти";
            this.войти.Size = new System.Drawing.Size(132, 53);
            this.войти.TabIndex = 0;
            this.войти.Text = "войти";
            this.войти.UseVisualStyleBackColor = true;
            this.войти.Click += new System.EventHandler(this.войти_Click);
            // 
            // логинBox
            // 
            this.логинBox.Font = new System.Drawing.Font("Dubai", 16.2F);
            this.логинBox.Location = new System.Drawing.Point(355, 181);
            this.логинBox.Name = "логинBox";
            this.логинBox.Size = new System.Drawing.Size(301, 53);
            this.логинBox.TabIndex = 1;
            // 
            // парольBox
            // 
            this.парольBox.Font = new System.Drawing.Font("Dubai", 16.2F);
            this.парольBox.Location = new System.Drawing.Point(355, 248);
            this.парольBox.Name = "парольBox";
            this.парольBox.Size = new System.Drawing.Size(301, 53);
            this.парольBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 16.2F);
            this.label2.Location = new System.Drawing.Point(212, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "пароль";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.парольBox);
            this.Controls.Add(this.логинBox);
            this.Controls.Add(this.войти);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button войти;
        private System.Windows.Forms.TextBox логинBox;
        private System.Windows.Forms.TextBox парольBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

