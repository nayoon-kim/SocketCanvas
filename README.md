# SocketCanvas
다중 소켓 통신을 이용하여 그림 데이터를 공유해 동시에 여러 사용자가 그림을 그릴 수 있는 세계그림판 프로그램

1. 폼 구성
서버 열기
![image](https://user-images.githubusercontent.com/53392870/81657439-d5a89800-9472-11ea-97bc-7c67140eb84f.png)

서버
![image](https://user-images.githubusercontent.com/53392870/81657339-c590b880-9472-11ea-9ef5-0207f67ef7e3.png)

클라이언트
![image](https://user-images.githubusercontent.com/53392870/81657406-d17c7a80-9472-11ea-88c1-63799b3b214d.png)

2. 그림판 구현
실시간 통신 화면
![image](https://user-images.githubusercontent.com/53392870/81657459-da6d4c00-9472-11ea-919d-f7005563d61a.png)

All_Shapes
![image](https://user-images.githubusercontent.com/53392870/81657488-e0632d00-9472-11ea-886e-3dd7d25e4660.png)

![image](https://user-images.githubusercontent.com/53392870/81657508-e48f4a80-9472-11ea-95c2-694906c4c067.png)

![image](https://user-images.githubusercontent.com/53392870/81657523-e6f1a480-9472-11ea-836a-7c334e2c737e.png)

![image](https://user-images.githubusercontent.com/53392870/81657536-ea852b80-9472-11ea-8ab9-05b83ba4bd5c.png)

![image](https://user-images.githubusercontent.com/53392870/81657547-ec4eef00-9472-11ea-9c12-1d89399cc7d5.png)

![image](https://user-images.githubusercontent.com/53392870/81657559-eeb14900-9472-11ea-8e23-f3e922452ddc.png)

![image](https://user-images.githubusercontent.com/53392870/81657577-f1ac3980-9472-11ea-9cc9-cca3d77efeba.png)

![image](https://user-images.githubusercontent.com/53392870/81657588-f375fd00-9472-11ea-85f3-71f2ca1a2284.png)

3. 화면조작
기존화면
![image](https://user-images.githubusercontent.com/53392870/81657603-f670ed80-9472-11ea-8cbc-78a503d75c4b.png)

화면 확대
![image](https://user-images.githubusercontent.com/53392870/81657614-f83ab100-9472-11ea-8eed-bd93af15587c.png)

마우스 스크롤에 의해서 변화하게 됨
![image](https://user-images.githubusercontent.com/53392870/81657623-fa9d0b00-9472-11ea-96d9-bc5c509ef825.png)

(setSize -> MyRect)
![image](https://user-images.githubusercontent.com/53392870/81657637-fcff6500-9472-11ea-868a-c9077296d8dd.png)

(MouseWheel)
![image](https://user-images.githubusercontent.com/53392870/81657645-fec92880-9472-11ea-8102-d5ace7401f9f.png)

(조작하고자 하는 클라이언트 외에 다른 클라이언트에는 화면 조작이 되지 않도록 함)
![image](https://user-images.githubusercontent.com/53392870/81657662-025caf80-9473-11ea-810f-c9b934307ea9.png)

(mouse up하였을 경우 서버로 데이터 넘어감)
![image](https://user-images.githubusercontent.com/53392870/81657676-04bf0980-9473-11ea-9710-0770bd4342da.png)

채팅
![image](https://user-images.githubusercontent.com/53392870/81657688-07b9fa00-9473-11ea-9703-884f6033e723.png)
