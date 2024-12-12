using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함
using System.Linq;

namespace Serial_Communication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label_temp.Text = "00.0";
            textBox_send.Text = "010300010001D5CA";
        }

        private void Form1_Load(object sender, EventArgs e)  //폼이 로드되면
        {
            //comboBox_port.DataSource = SerialPort.GetPortNames(); //연결 가능한 시리얼포트 이름을 콤보박스에 가져오기 


            // 시리얼 포트 이름을 가져와서 알파벳 순으로 정렬
            string[] ports = SerialPort.GetPortNames();
            var sortedPorts = ports.OrderBy(port => port).ToArray();  // 알파벳 순으로 정렬

            // 정렬된 포트를 ComboBox에 바인딩
            comboBox_port.DataSource = sortedPorts;
        }

        private void Button_connect_Click(object sender, EventArgs e)  //통신 연결하기 버튼
        {
            if (!serialPort1.IsOpen)  //시리얼포트가 열려 있지 않으면
            {
                serialPort1.PortName = comboBox_port.Text;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                serialPort1.BaudRate = 9600;  //보레이트 변경이 필요하면 숫자 변경하기
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

                serialPort1.Open();  //시리얼포트 열기

                label_status.Text = "포트가 열렸습니다.";
                comboBox_port.Enabled = false;  //COM포트설정 콤보박스 비활성화

                timer1.Enabled = true;
            }
            else  //시리얼포트가 열려 있으면
            {
                label_status.Text = "포트가 이미 열려 있습니다.";
                timer1.Enabled = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            this.Invoke(new EventHandler(MySerialReceived));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
        }

        private StringBuilder receivedDataBuffer = new StringBuilder();

        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            //int ReceiveData = serialPort1.ReadByte();  //시리얼 버터에 수신된 데이타를 ReceiveData 읽어오기
            //richTextBox_received.Text = richTextBox_received.Text + string.Format("{0:X2}", ReceiveData);  //int 형식을 string형식으로 변환하여 출력
            try
            {
                // 수신된 데이터의 바이트 수 확인
                int bytesToRead = serialPort1.BytesToRead;

                // 수신된 데이터를 읽어 버퍼에 저장
                byte[] buffer = new byte[bytesToRead];
                serialPort1.Read(buffer, 0, bytesToRead);

                // 버퍼에 저장된 데이터를 16진수 형식으로 변환하여 richTextBox에 출력
                foreach (byte b in buffer)
                {
                    // 데이터를 16진수 형식으로 변환하여 텍스트 박스에 추가
                    receivedDataBuffer.AppendFormat("{0:X2} ", b);
                }

                if (buffer[0] == 01 && buffer[1] == 03 && buffer[2] == 02)
                {
                    float calculatedValue = (buffer[3] * 256 + buffer[4]) / 10.0f;
                    // 계산된 값을 label_temp.Text에 문자열로 표시
                    label_temp.Text = calculatedValue.ToString();
                }

                // 데이터를 화면에 출력 (UI 스레드에서 안전하게 처리)
                richTextBox_received.Invoke(new Action(() =>
                {
                    richTextBox_received.Text = receivedDataBuffer.ToString() + "\r\n"; // 줄 바꿈 추가
                    //richTextBox_received.Text = receivedDataBuffer.ToString();
                    // 자동 스크롤 설정
                    richTextBox_received.SelectionStart = richTextBox_received.Text.Length;
                    richTextBox_received.ScrollToCaret();
                }));
            }
            catch (Exception ex)
            {
                // 예외 처리
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Button_send_Click(object sender, EventArgs e)  //보내기 버튼을 클릭하면
        {
            // 초기 데이터 : 01,03,00,01,00,01
            // CRC16 적용  : 01,03,00,01,00,01,D5,CA  -> 010300010001D5CA
            // 수신 데이터 : 01,03,02,01,2C,B8,09, (01, 2C -> 300)
            // 010300010001 -> 01,03,00,01,00,01,D5,CA
            // Hex 문자열을 바이트 배열로 변환
            //serialPort1.Write(textBox_send.Text);  //텍스트박스의 텍스트를 시리얼통신으로 송신
            //serialPort1.Write(ToString.send_bytes);  //텍스트박스의 텍스트를 시리얼통신으로 송신
            byte[] byteArray = new byte[textBox_send.Text.Length / 2];

            for (int i = 0; i < textBox_send.Text.Length; i += 2)
            {
                // 2글자씩 묶어서 하나의 바이트로 변환
                string hexByte = textBox_send.Text.Substring(i, 2);
                byteArray[i / 2] = Convert.ToByte(hexByte, 16);
            }
            serialPort1.Write(byteArray, 0, byteArray.Length);
        }

        private void Button_disconnect_Click(object sender, EventArgs e)  //통신 연결끊기 버튼
        {
            if (serialPort1.IsOpen)  //시리얼포트가 열려 있으면
            {
                serialPort1.Close();  //시리얼포트 닫기

                label_status.Text = "포트가 닫혔습니다.";
                comboBox_port.Enabled = true;  //COM포트설정 콤보박스 활성화
            }
            else  //시리얼포트가 닫혀 있으면
            {
                label_status.Text = "포트가 이미 닫혀 있습니다.";
            }
            timer1.Enabled = false;
        }

        private ushort Crc16Ccitt(byte[] bytes)
        {
            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0xffff;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] byteArray = new byte[textBox_send.Text.Length / 2];

            for (int i = 0; i < textBox_send.Text.Length; i += 2)
            {
                // 2글자씩 묶어서 하나의 바이트로 변환
                string hexByte = textBox_send.Text.Substring(i, 2);
                byteArray[i / 2] = Convert.ToByte(hexByte, 16);
            }
            serialPort1.Write(byteArray, 0, byteArray.Length);
        }
    }
}
