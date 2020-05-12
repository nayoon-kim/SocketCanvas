# SocketCanvas
다중 소켓 통신을 이용하여 그림 데이터를 공유해 동시에 여러 사용자가 그림을 그릴 수 있는 세계그림판 프로그램

C#, Winform 

그림판 기능, 다중 클라이언트와의 통신, 화면 조작, 채팅으로 총 4가지 기능으로 이루어져 있습니다.

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

Panel_MouseMove, MouseUp

![image](https://user-images.githubusercontent.com/53392870/81657488-e0632d00-9472-11ea-886e-3dd7d25e4660.png) ![image](https://user-images.githubusercontent.com/53392870/81657508-e48f4a80-9472-11ea-95c2-694906c4c067.png)

DataReceived

![image](https://user-images.githubusercontent.com/53392870/81657523-e6f1a480-9472-11ea-836a-7c334e2c737e.png) ![image](https://user-images.githubusercontent.com/53392870/81657536-ea852b80-9472-11ea-8ab9-05b83ba4bd5c.png)

obj.WorkingSocket이라는 socket 객체를 통해서 비동기적으로 데이터를 받고 받은 데이터를 byte의 앞부분 4부분만 따서 text일 경우에는 채팅 데이터이므로 데이터를 string으로 처리하고 그렇지 않을 경우에는 All_Shapes이므로 도형으로 그림을 처리한다.

InitSocket

![image](https://user-images.githubusercontent.com/53392870/81657547-ec4eef00-9472-11ea-9c12-1d89399cc7d5.png)

<mainSock는 socket 객체이고 클라이언트는 이 socket을 통해서 서버와 통신하는데 비동기 소켓 통신을 진행할 것이다. 따라서 BeginReceive라는 메소드를 사용하여서 데이터를 받게 되면 언제든지 데이터 통신을 기다리는 DataReceived 메소드를 실행한다.>

3. 다중 클라이언트 구현

<다중 클라이언트에게 그림판의 화면을 전송할 수 있다>

![image](https://user-images.githubusercontent.com/53392870/81657559-eeb14900-9472-11ea-8e23-f3e922452ddc.png)

![image](https://user-images.githubusercontent.com/53392870/81657676-04bf0980-9473-11ea-9710-0770bd4342da.png)

<Mouse-Up을 하였을 경우 클라이언트에서 서버로 데이터를 전송한다>

![image](https://user-images.githubusercontent.com/53392870/81657577-f1ac3980-9472-11ea-9cc9-cca3d77efeba.png)

<서버에서 클라이언트에게 받은 데이터를 다른 클라이언트에게 전송한다>

![image](https://user-images.githubusercontent.com/53392870/81657588-f375fd00-9472-11ea-85f3-71f2ca1a2284.png)

<클라이언트에서 서버에게 데이터를 받고 처리한다.>

4. 화면조작

기존화면

![image](https://user-images.githubusercontent.com/53392870/81657603-f670ed80-9472-11ea-8cbc-78a503d75c4b.png)

화면 확대

![image](https://user-images.githubusercontent.com/53392870/81657614-f83ab100-9472-11ea-8eed-bd93af15587c.png)

화면 조작 중인 클라이언트와 그렇지 않은 클라이언트

![image](https://user-images.githubusercontent.com/53392870/81657662-025caf80-9473-11ea-810f-c9b934307ea9.png)

panel_MouseWheel

![image](https://user-images.githubusercontent.com/53392870/81657623-fa9d0b00-9472-11ea-96d9-bc5c509ef825.png)

<Wheel을 위로 올리면 축소> -> 0.9 비율로 축소 + wheel_line도 축소됨

<Wheel을 아래로 내리면 확대> -> 1.1 비율로 확대 + wheel_line도 확대됨

panel_MouseWheel

![image](https://user-images.githubusercontent.com/53392870/81657645-fec92880-9472-11ea-8102-d5ace7401f9f.png)

<위의 코드는 각각의 All_Shapes의 자식 클래스들이 type에 따라 setSize를 구현하게 된다.>

setSize

![image](https://user-images.githubusercontent.com/53392870/81657637-fcff6500-9472-11ea-868a-c9077296d8dd.png)


5. 채팅

![image](https://user-images.githubusercontent.com/53392870/81657688-07b9fa00-9473-11ea-9703-884f6033e723.png)


19.05~19.06
