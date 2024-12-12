Modbus-RTU 422 통신 관련
            
            // 초기 데이터 : 01,03,00,01,00,01
            // 초기 데이터 + CRC16 적용  : 01,03,00,01,00,01,D5,CA  -> 010300010001D5CA
            // 수신 데이터 : 01,03,02,01,2C,B8,09, (01, 2C -> 300)

//Version 1

![Serial_Communication](https://github.com/user-attachments/assets/193acc30-a830-45d1-944a-bbab705efa99)


//Version 2

![Serial_Communication_01](https://github.com/user-attachments/assets/b8c0414d-b3cc-40dc-864c-aec5bd8fa357)


            # C# CRC-16

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
