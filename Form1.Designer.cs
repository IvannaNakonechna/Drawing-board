namespace Projekt3
{
    partial class KokpitProjektuNr3
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
            this.label_KokpitProjektuNr3 = new System.Windows.Forms.Label();
            this.btn_lab = new System.Windows.Forms.Button();
            this.btnlnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_KokpitProjektuNr3
            // 
            this.label_KokpitProjektuNr3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_KokpitProjektuNr3.BackColor = System.Drawing.SystemColors.Control;
            this.label_KokpitProjektuNr3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_KokpitProjektuNr3.ForeColor = System.Drawing.Color.Red;
            this.label_KokpitProjektuNr3.Location = new System.Drawing.Point(145, 48);
            this.label_KokpitProjektuNr3.Name = "label_KokpitProjektuNr3";
            this.label_KokpitProjektuNr3.Size = new System.Drawing.Size(603, 71);
            this.label_KokpitProjektuNr3.TabIndex = 0;
            this.label_KokpitProjektuNr3.Text = "KOKPIT PROJEKTU Nr 3                                           (Kreślenie figur, " +
    "krzywych i linii geometrycznych)";
            // 
            // btn_lab
            // 
            this.btn_lab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_lab.Location = new System.Drawing.Point(70, 202);
            this.btn_lab.Name = "btn_lab";
            this.btn_lab.Size = new System.Drawing.Size(191, 76);
            this.btn_lab.TabIndex = 1;
            this.btn_lab.Text = "Labaratorium Nr 3 (Kreślenie krzywych geometrycznych)";
            this.btn_lab.UseVisualStyleBackColor = true;
            this.btn_lab.Click += new System.EventHandler(this.btn_lab_Click);
            // 
            // btnlnd
            // 
            this.btnlnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnlnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnlnd.Location = new System.Drawing.Point(520, 202);
            this.btnlnd.Name = "btnlnd";
            this.btnlnd.Size = new System.Drawing.Size(207, 75);
            this.btnlnd.TabIndex = 2;
            this.btnlnd.Text = "Projekt Nr 3 (Kreślenie krzywych i linii geometrycznych)";
            this.btnlnd.UseVisualStyleBackColor = true;
            this.btnlnd.Click += new System.EventHandler(this.btnlnd_Click);
            // 
            // KokpitProjektuNr3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnlnd);
            this.Controls.Add(this.btn_lab);
            this.Controls.Add(this.label_KokpitProjektuNr3);
            this.Name = "KokpitProjektuNr3";
            this.Text = "Kokpit Projektu Nr 3";
            
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_KokpitProjektuNr3;
        private System.Windows.Forms.Button btn_lab;
        private System.Windows.Forms.Button btnlnd;
    }
}

