namespace Serial_Communication
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.richTextBox_received = new System.Windows.Forms.RichTextBox();
            this.label_send = new System.Windows.Forms.Label();
            this.label_receive = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_status = new System.Windows.Forms.Label();
            this.label_temp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(16, 49);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(118, 20);
            this.comboBox_port.TabIndex = 0;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(16, 86);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(116, 44);
            this.button_connect.TabIndex = 1;
            this.button_connect.Text = "연결하기";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.Button_connect_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(157, 86);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(116, 44);
            this.button_disconnect.TabIndex = 1;
            this.button_disconnect.Text = "연결끊기";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.Button_disconnect_Click);
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(20, 411);
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(159, 21);
            this.textBox_send.TabIndex = 2;
            // 
            // richTextBox_received
            // 
            this.richTextBox_received.Location = new System.Drawing.Point(16, 277);
            this.richTextBox_received.Name = "richTextBox_received";
            this.richTextBox_received.Size = new System.Drawing.Size(281, 86);
            this.richTextBox_received.TabIndex = 3;
            this.richTextBox_received.Text = "";
            // 
            // label_send
            // 
            this.label_send.AutoSize = true;
            this.label_send.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_send.ForeColor = System.Drawing.Color.White;
            this.label_send.Location = new System.Drawing.Point(16, 379);
            this.label_send.Name = "label_send";
            this.label_send.Size = new System.Drawing.Size(49, 19);
            this.label_send.TabIndex = 4;
            this.label_send.Text = "송신";
            // 
            // label_receive
            // 
            this.label_receive.AutoSize = true;
            this.label_receive.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_receive.ForeColor = System.Drawing.Color.Transparent;
            this.label_receive.Location = new System.Drawing.Point(16, 245);
            this.label_receive.Name = "label_receive";
            this.label_receive.Size = new System.Drawing.Size(47, 19);
            this.label_receive.TabIndex = 4;
            this.label_receive.Text = "수신";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_port.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_port.Location = new System.Drawing.Point(15, 20);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(117, 16);
            this.label_port.TabIndex = 5;
            this.label_port.Text = "COM 포트 설정";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(183, 396);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(114, 49);
            this.button_send.TabIndex = 6;
            this.button_send.Text = "보내기";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.Button_send_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_status.Location = new System.Drawing.Point(154, 49);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(71, 16);
            this.label_status.TabIndex = 7;
            this.label_status.Text = "연결상태";
            // 
            // label_temp
            // 
            this.label_temp.AutoSize = true;
            this.label_temp.Font = new System.Drawing.Font("Siemens Sans", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_temp.ForeColor = System.Drawing.Color.Red;
            this.label_temp.Location = new System.Drawing.Point(144, 163);
            this.label_temp.Name = "label_temp";
            this.label_temp.Size = new System.Drawing.Size(161, 76);
            this.label_temp.TabIndex = 8;
            this.label_temp.Text = "00.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "PV : ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(317, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_temp);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_receive);
            this.Controls.Add(this.label_send);
            this.Controls.Add(this.richTextBox_received);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.comboBox_port);
            this.Name = "Form1";
            this.Text = "Serial_Communication";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.RichTextBox richTextBox_received;
        private System.Windows.Forms.Label label_send;
        private System.Windows.Forms.Label label_receive;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Button button_send;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label_temp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

