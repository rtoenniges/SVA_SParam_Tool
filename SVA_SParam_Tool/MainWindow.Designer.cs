namespace SVA_SParam_Tool
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_tcp_connect = new System.Windows.Forms.Button();
            this.edit_tcp_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edit_tcp_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_mode_vna = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_plot_smith = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_measure_s11 = new System.Windows.Forms.Button();
            this.btn_measure_s21 = new System.Windows.Forms.Button();
            this.smith_plot_s11 = new ScottPlot.WinForms.FormsPlot();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.smith_plot_s21 = new ScottPlot.WinForms.FormsPlot();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_load_data = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_save_s2p = new System.Windows.Forms.Button();
            this.btn_save_s1p = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_start_freq = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.text_stop_freq = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.text_sweep_points = new System.Windows.Forms.TextBox();
            this.btn_tcp_refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tcp_connect
            // 
            this.btn_tcp_connect.Location = new System.Drawing.Point(221, 141);
            this.btn_tcp_connect.Name = "btn_tcp_connect";
            this.btn_tcp_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_tcp_connect.TabIndex = 0;
            this.btn_tcp_connect.Text = "Connect";
            this.btn_tcp_connect.UseVisualStyleBackColor = true;
            // 
            // edit_tcp_ip
            // 
            this.edit_tcp_ip.Location = new System.Drawing.Point(12, 143);
            this.edit_tcp_ip.Name = "edit_tcp_ip";
            this.edit_tcp_ip.Size = new System.Drawing.Size(100, 20);
            this.edit_tcp_ip.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "1. Connect";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP-Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port:";
            // 
            // edit_tcp_port
            // 
            this.edit_tcp_port.Location = new System.Drawing.Point(135, 143);
            this.edit_tcp_port.Name = "edit_tcp_port";
            this.edit_tcp_port.Size = new System.Drawing.Size(58, 20);
            this.edit_tcp_port.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "2. Set VNA Mode";
            // 
            // btn_mode_vna
            // 
            this.btn_mode_vna.Location = new System.Drawing.Point(12, 232);
            this.btn_mode_vna.Name = "btn_mode_vna";
            this.btn_mode_vna.Size = new System.Drawing.Size(75, 23);
            this.btn_mode_vna.TabIndex = 8;
            this.btn_mode_vna.Text = "VNA";
            this.btn_mode_vna.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "3. Show Smith Plot";
            // 
            // btn_plot_smith
            // 
            this.btn_plot_smith.Enabled = false;
            this.btn_plot_smith.Location = new System.Drawing.Point(12, 321);
            this.btn_plot_smith.Name = "btn_plot_smith";
            this.btn_plot_smith.Size = new System.Drawing.Size(75, 23);
            this.btn_plot_smith.TabIndex = 10;
            this.btn_plot_smith.Text = "Smith";
            this.btn_plot_smith.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "4. Choose Measure";
            // 
            // btn_measure_s11
            // 
            this.btn_measure_s11.Enabled = false;
            this.btn_measure_s11.Location = new System.Drawing.Point(12, 52);
            this.btn_measure_s11.Name = "btn_measure_s11";
            this.btn_measure_s11.Size = new System.Drawing.Size(75, 23);
            this.btn_measure_s11.TabIndex = 12;
            this.btn_measure_s11.Text = "S11";
            this.btn_measure_s11.UseVisualStyleBackColor = true;
            // 
            // btn_measure_s21
            // 
            this.btn_measure_s21.Enabled = false;
            this.btn_measure_s21.Location = new System.Drawing.Point(124, 52);
            this.btn_measure_s21.Name = "btn_measure_s21";
            this.btn_measure_s21.Size = new System.Drawing.Size(75, 23);
            this.btn_measure_s21.TabIndex = 13;
            this.btn_measure_s21.Text = "S21";
            this.btn_measure_s21.UseVisualStyleBackColor = true;
            // 
            // smith_plot_s11
            // 
            this.smith_plot_s11.DisplayScale = 0F;
            this.smith_plot_s11.Enabled = false;
            this.smith_plot_s11.Location = new System.Drawing.Point(508, 64);
            this.smith_plot_s11.Name = "smith_plot_s11";
            this.smith_plot_s11.Size = new System.Drawing.Size(250, 250);
            this.smith_plot_s11.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(505, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "S11";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "S21";
            // 
            // smith_plot_s21
            // 
            this.smith_plot_s21.DisplayScale = 0F;
            this.smith_plot_s21.Enabled = false;
            this.smith_plot_s21.Location = new System.Drawing.Point(508, 365);
            this.smith_plot_s21.Name = "smith_plot_s21";
            this.smith_plot_s21.Size = new System.Drawing.Size(250, 250);
            this.smith_plot_s21.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "5. Load";
            // 
            // btn_load_data
            // 
            this.btn_load_data.Enabled = false;
            this.btn_load_data.Location = new System.Drawing.Point(12, 135);
            this.btn_load_data.Name = "btn_load_data";
            this.btn_load_data.Size = new System.Drawing.Size(75, 23);
            this.btn_load_data.TabIndex = 19;
            this.btn_load_data.Text = "Load";
            this.btn_load_data.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 532);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 24);
            this.label11.TabIndex = 20;
            this.label11.Text = "6. Save";
            // 
            // btn_save_s2p
            // 
            this.btn_save_s2p.Enabled = false;
            this.btn_save_s2p.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_s2p.Location = new System.Drawing.Point(144, 570);
            this.btn_save_s2p.Name = "btn_save_s2p";
            this.btn_save_s2p.Size = new System.Drawing.Size(100, 45);
            this.btn_save_s2p.TabIndex = 22;
            this.btn_save_s2p.Text = "*.s2p";
            this.btn_save_s2p.UseVisualStyleBackColor = true;
            // 
            // btn_save_s1p
            // 
            this.btn_save_s1p.Enabled = false;
            this.btn_save_s1p.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_s1p.Location = new System.Drawing.Point(12, 570);
            this.btn_save_s1p.Name = "btn_save_s1p";
            this.btn_save_s1p.Size = new System.Drawing.Size(100, 45);
            this.btn_save_s1p.TabIndex = 21;
            this.btn_save_s1p.Text = "*.s1p";
            this.btn_save_s1p.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_load_data);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btn_measure_s21);
            this.panel1.Controls.Add(this.btn_measure_s11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 173);
            this.panel1.TabIndex = 23;
            // 
            // text_start_freq
            // 
            this.text_start_freq.Location = new System.Drawing.Point(309, 212);
            this.text_start_freq.Name = "text_start_freq";
            this.text_start_freq.ReadOnly = true;
            this.text_start_freq.Size = new System.Drawing.Size(100, 20);
            this.text_start_freq.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(309, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Start Frequency:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(309, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Stop Frequency:";
            // 
            // text_stop_freq
            // 
            this.text_stop_freq.Location = new System.Drawing.Point(309, 261);
            this.text_stop_freq.Name = "text_stop_freq";
            this.text_stop_freq.ReadOnly = true;
            this.text_stop_freq.Size = new System.Drawing.Size(100, 20);
            this.text_stop_freq.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(309, 307);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Sweep Points:";
            // 
            // text_sweep_points
            // 
            this.text_sweep_points.Location = new System.Drawing.Point(309, 321);
            this.text_sweep_points.Name = "text_sweep_points";
            this.text_sweep_points.ReadOnly = true;
            this.text_sweep_points.Size = new System.Drawing.Size(100, 20);
            this.text_sweep_points.TabIndex = 28;
            // 
            // btn_tcp_refresh
            // 
            this.btn_tcp_refresh.Enabled = false;
            this.btn_tcp_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tcp_refresh.Location = new System.Drawing.Point(312, 141);
            this.btn_tcp_refresh.Name = "btn_tcp_refresh";
            this.btn_tcp_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_tcp_refresh.TabIndex = 30;
            this.btn_tcp_refresh.Text = "Refresh";
            this.btn_tcp_refresh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "S-Parameter Tool for SSA/SVA";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 645);
            this.Controls.Add(this.btn_tcp_refresh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.text_sweep_points);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.text_stop_freq);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.text_start_freq);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_save_s2p);
            this.Controls.Add(this.btn_save_s1p);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.smith_plot_s21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.smith_plot_s11);
            this.Controls.Add(this.btn_plot_smith);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_mode_vna);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edit_tcp_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edit_tcp_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_tcp_connect);
            this.Name = "MainWindow";
            this.Text = "S-Parameter Tool for SSA/SVA by Robin Tönniges (DC7RT)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_tcp_connect;
        private System.Windows.Forms.TextBox edit_tcp_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edit_tcp_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_mode_vna;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_plot_smith;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_measure_s11;
        private System.Windows.Forms.Button btn_measure_s21;
        private ScottPlot.WinForms.FormsPlot smith_plot_s11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ScottPlot.WinForms.FormsPlot smith_plot_s21;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_load_data;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_save_s2p;
        private System.Windows.Forms.Button btn_save_s1p;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox text_start_freq;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_stop_freq;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox text_sweep_points;
        private System.Windows.Forms.Button btn_tcp_refresh;
        private System.Windows.Forms.Label label1;
    }
}

