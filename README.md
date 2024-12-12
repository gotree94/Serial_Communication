Modbus-RTU 422 통신 관련
            
// 초기 데이터 : 01,03,00,01,00,01
// 초기 데이터 + CRC16 적용  : 01,03,00,01,00,01,D5,CA  -> 010300010001D5CA
// 수신 데이터 : 01,03,02,01,2C,B8,09, (01, 2C -> 300)

![Serial_Communication](https://github.com/user-attachments/assets/193acc30-a830-45d1-944a-bbab705efa99)
