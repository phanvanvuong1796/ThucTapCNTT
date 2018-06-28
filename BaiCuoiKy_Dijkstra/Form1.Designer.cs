namespace BaiCuoiKy_Dijkstra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClickEnd = new System.Windows.Forms.Button();
            this.btnClickStart = new System.Windows.Forms.Button();
            this.btnEndPoint = new System.Windows.Forms.Button();
            this.btnStartPoint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndPoint = new System.Windows.Forms.TextBox();
            this.txtStartPoint = new System.Windows.Forms.TextBox();
            this.btnDrawEdges = new System.Windows.Forms.Button();
            this.btnDrawPoint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberEdges = new System.Windows.Forms.TextBox();
            this.txtNumberPoints = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ptbBackground = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBackground)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClickEnd);
            this.groupBox1.Controls.Add(this.btnClickStart);
            this.groupBox1.Controls.Add(this.btnEndPoint);
            this.groupBox1.Controls.Add(this.btnStartPoint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEndPoint);
            this.groupBox1.Controls.Add(this.txtStartPoint);
            this.groupBox1.Controls.Add(this.btnDrawEdges);
            this.groupBox1.Controls.Add(this.btnDrawPoint);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumberEdges);
            this.groupBox1.Controls.Add(this.txtNumberPoints);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu đầu vào";
            // 
            // btnClickEnd
            // 
            this.btnClickEnd.Location = new System.Drawing.Point(174, 185);
            this.btnClickEnd.Name = "btnClickEnd";
            this.btnClickEnd.Size = new System.Drawing.Size(43, 20);
            this.btnClickEnd.TabIndex = 13;
            this.btnClickEnd.Text = "Pick";
            this.btnClickEnd.UseVisualStyleBackColor = true;
            this.btnClickEnd.Click += new System.EventHandler(this.btnClickEnd_Click);
            // 
            // btnClickStart
            // 
            this.btnClickStart.Location = new System.Drawing.Point(174, 135);
            this.btnClickStart.Name = "btnClickStart";
            this.btnClickStart.Size = new System.Drawing.Size(43, 20);
            this.btnClickStart.TabIndex = 12;
            this.btnClickStart.Text = "Pick";
            this.btnClickStart.UseVisualStyleBackColor = true;
            this.btnClickStart.Click += new System.EventHandler(this.btnClickStart_Click);
            // 
            // btnEndPoint
            // 
            this.btnEndPoint.Location = new System.Drawing.Point(115, 185);
            this.btnEndPoint.Name = "btnEndPoint";
            this.btnEndPoint.Size = new System.Drawing.Size(43, 20);
            this.btnEndPoint.TabIndex = 11;
            this.btnEndPoint.Text = "Chọn";
            this.btnEndPoint.UseVisualStyleBackColor = true;
            this.btnEndPoint.Click += new System.EventHandler(this.btnEndPoint_Click);
            // 
            // btnStartPoint
            // 
            this.btnStartPoint.Location = new System.Drawing.Point(115, 136);
            this.btnStartPoint.Name = "btnStartPoint";
            this.btnStartPoint.Size = new System.Drawing.Size(43, 20);
            this.btnStartPoint.TabIndex = 10;
            this.btnStartPoint.Text = "Chọn";
            this.btnStartPoint.UseVisualStyleBackColor = true;
            this.btnStartPoint.Click += new System.EventHandler(this.btnStartPoint_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bắt đầu";
            // 
            // txtEndPoint
            // 
            this.txtEndPoint.Location = new System.Drawing.Point(69, 185);
            this.txtEndPoint.Name = "txtEndPoint";
            this.txtEndPoint.Size = new System.Drawing.Size(33, 20);
            this.txtEndPoint.TabIndex = 7;
            this.txtEndPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndPoint_KeyDown);
            // 
            // txtStartPoint
            // 
            this.txtStartPoint.Location = new System.Drawing.Point(69, 136);
            this.txtStartPoint.Name = "txtStartPoint";
            this.txtStartPoint.Size = new System.Drawing.Size(33, 20);
            this.txtStartPoint.TabIndex = 6;
            this.txtStartPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartPoint_KeyDown);
            // 
            // btnDrawEdges
            // 
            this.btnDrawEdges.Location = new System.Drawing.Point(174, 75);
            this.btnDrawEdges.Name = "btnDrawEdges";
            this.btnDrawEdges.Size = new System.Drawing.Size(43, 20);
            this.btnDrawEdges.TabIndex = 5;
            this.btnDrawEdges.Text = "vẽ";
            this.btnDrawEdges.UseVisualStyleBackColor = true;
            this.btnDrawEdges.Click += new System.EventHandler(this.btnDrawEdges_Click);
            // 
            // btnDrawPoint
            // 
            this.btnDrawPoint.Location = new System.Drawing.Point(174, 26);
            this.btnDrawPoint.Name = "btnDrawPoint";
            this.btnDrawPoint.Size = new System.Drawing.Size(43, 20);
            this.btnDrawPoint.TabIndex = 4;
            this.btnDrawPoint.Text = "vẽ";
            this.btnDrawPoint.UseVisualStyleBackColor = true;
            this.btnDrawPoint.Click += new System.EventHandler(this.btnDrawPoint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số đường";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số điểm";
            // 
            // txtNumberEdges
            // 
            this.txtNumberEdges.Location = new System.Drawing.Point(69, 76);
            this.txtNumberEdges.Name = "txtNumberEdges";
            this.txtNumberEdges.Size = new System.Drawing.Size(89, 20);
            this.txtNumberEdges.TabIndex = 1;
            this.txtNumberEdges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumberEdges_KeyDown);
            // 
            // txtNumberPoints
            // 
            this.txtNumberPoints.Location = new System.Drawing.Point(69, 27);
            this.txtNumberPoints.Name = "txtNumberPoints";
            this.txtNumberPoints.Size = new System.Drawing.Size(89, 20);
            this.txtNumberPoints.TabIndex = 0;
            this.txtNumberPoints.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumberPoints_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ptbBackground);
            this.groupBox2.Location = new System.Drawing.Point(242, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 624);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đồ thị";
            // 
            // ptbBackground
            // 
            this.ptbBackground.Location = new System.Drawing.Point(6, 18);
            this.ptbBackground.Name = "ptbBackground";
            this.ptbBackground.Size = new System.Drawing.Size(600, 600);
            this.ptbBackground.TabIndex = 0;
            this.ptbBackground.TabStop = false;
            this.ptbBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbBackground_MouseDown);
            this.ptbBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbBackground_MouseMove);
            this.ptbBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbBackground_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbResult);
            this.groupBox3.Controls.Add(this.btnShowResult);
            this.groupBox3.Location = new System.Drawing.Point(3, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 372);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Điều khiển";
            // 
            // btnShowResult
            // 
            this.btnShowResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowResult.Location = new System.Drawing.Point(42, 48);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(141, 58);
            this.btnShowResult.TabIndex = 2;
            this.btnShowResult.Text = "Kết quả";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResult.Location = new System.Drawing.Point(6, 125);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(221, 77);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 641);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBackground)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDrawEdges;
        private System.Windows.Forms.Button btnDrawPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumberEdges;
        private System.Windows.Forms.TextBox txtNumberPoints;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox ptbBackground;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.Button btnEndPoint;
        private System.Windows.Forms.Button btnStartPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEndPoint;
        private System.Windows.Forms.TextBox txtStartPoint;
        private System.Windows.Forms.Button btnClickEnd;
        private System.Windows.Forms.Button btnClickStart;
        private System.Windows.Forms.RichTextBox rtbResult;
    }
}

