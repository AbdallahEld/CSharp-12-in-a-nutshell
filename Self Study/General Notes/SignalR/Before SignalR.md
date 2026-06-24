# How Internet Work
Internet Is Built to work with `HTTP` Protocol The Rule is:
Client (**Browser**) send request server (**Website**) send back response so developers needed to find a way to build real time applications like chat apps, video games, etc.
## Workarounds
Developers needed to find workarounds so they can add real time functionality to their applications so they invented some ways to do that.
### Short Polling
Client send a request every 5 seconds  to server check if there is new data the server sent it back to client if not, server send empty request
```
+--------+                               +--------+
|        |       1. Is there data?       |        |
|        |------------------------------>|        |
|        |                               |        |
|        |       2. No new data (Empty)  |        |
|        |<------------------------------|        |
|        |                               |        |
|        |==============================>|        |
|        |      [ Wait 5 Seconds ]       |        |
|        |==============================>|        |
|        |                               |        |
| CLIENT |       3. Is there data?       | SERVER |
|        |------------------------------>|        |
|        |                               |        |
|        |       4. No new data (Empty)  |        |
|        |<------------------------------|        |
|        |                               |        |
|        |==============================>|        |
|        |      [ Wait 5 Seconds ]       |        |
|        |==============================>|        |
|        |                               |        |
|        |       5. Is there data?       |        |
|        |------------------------------>|        |
|        |                               |        |
|        |       6. Yes! Here is data    |        |
|        |<------------------------------|        |
+--------+                               +--------+
```
#### Issue
Sending a request every 5 seconds does not look like the best idea in the world, imagine 1000 user every one of them sending request every 5 seconds, so you have around 12000 Request in just 1 minute ❌
### Long Polling
Client send request, server hold request for a time until new data come then it send request back to client
```
+--------+                               +--------+
|        |       1. Is there data?       |        |
|        |------------------------------>|        |
|        |                               |        |
|        |    [ SERVER HOLDS REQUEST ]   |        |
|        |    [ Client is waiting... ]   |        |
|        |    [   ...still waiting...]   |        |
|        |                               |New Data|
|        |       2. Yes! Here is data    |Arrives!|
|        |<------------------------------|        |
|        |                               +--------+
| CLIENT |                               |        |
|        |  3. Immediately asks again    |        |
|        |------------------------------>|        |
|        |                               |        |
|        |    [ SERVER HOLDS REQUEST ]   |        |
|        |    [ Client is waiting... ]   |        |
|        |                               |        |
|        |  4. Timeout! (No new data)    |        |
|        |<------------------------------|        |
|        |                               |        |
|        |  5. Immediately asks again    |        |
|        |------------------------------>|        |
+--------+                               +--------+
```
#### Issue
yeah it maybe looks better then the previous one but there is still an issue "**Connection Timeout**" if the server take more than 30 second to Response to user the Timeout will happen 
### Chunks Encoding - Forever Frame
Developers find another way by using a feature in HTTP protocol called Chunks Encoding
#### What is Chunks Encoding 
When Client is trying to access data from server but the server do not know what is the size of this data for example (**Video streaming**) it tell the browser that he will receive chunks of data `Transfer-Encoding: chunked`.
Here browser start dealing with each chunk
```
+--------+                               +--------+
|        |       1. Request Resource     |        |
|        |------------------------------>|        |
|        |                               |        |
|        | 2. HTTP/1.1 200 OK            |        |
|        |    Transfer-Encoding: chunked |        |
|        |<------------------------------|        |
|        |                               |        |
| CLIENT |       3. [ Chunk 1 Data ]     | SERVER |
|        |<------------------------------|        |
|        |                               |        |
|        |       4. [ Chunk 2 Data ]     |        |
|        |<------------------------------|        |
|        |                               |        |
|        |       5. 0 (Final Empty Chunk)|        |
|        |<------------------------------|        |
+--------+                               +--------+
```
So what developers do that they used this feature by making hidden frame and let the connection always open between client and server sending chunks
```
+-------------------------------------------------------------+
| CLIENT (Main Web Page)                                      |
|                                                             |
|  +------------------+                                       |
|  | Hidden <iframe>  |                                       |
|  |                  |    1. Request continuous page         |
|  |                  |----------------------------------+    |
|  |                  |                                  |    |
|  |                  |    2. Pushes: <script>           |    |
|  |                  |       parent.update("Hello")     |    |
|  |                  |<---------------------------------+    |
|  | Executes script! |                                  |    |
|  |        |         |                                  |    |
|  +--------|---------+                                  |    |
|           | (Calls function on main page)              |    |
|           v                                            |    |
|  [ Updates Main UI ]                                   |    |
|                                                        |    |
|  +------------------+                                  v    |
|  | Hidden <iframe>  |    3. Pushes: <script>       +--------+
|  |                  |       parent.update("World") | SERVER |
|  |                  |<-----------------------------|        |
+--+------------------+------------------------------+--------+
```
### Server Send Event
When HTML5 invented came with it a new technique for the HTTP that allow for a streaming to be opened between client and server called **SSE**
#### How it works
it start with a normal HTTP request from browser but with additional informations `text/event-stream` telling the server i want to receive stream , then the server respond and a **Unidirectional** stream is opened, The browser keep sending chunks
```
+--------+                               +--------+
|        |       1. Request stream       |        |
|        |------------------------------>|        |
|        |                               |        |
|        | 2. HTTP/1.1 200 OK            |        |
|        |    Content-Type: text/event-stream     |
|        |    Cache-Control: no-cache    |        |
|        |<------------------------------|        |
|        |                               |        |
|        |       ~ Connection Kept Open ~         |
| CLIENT |                               | SERVER |
|        | 3. data: {"user": "Alice"}    |        |
|        |<------------------------------|        |
|        |                               | * Server
|        | 4. data: {"user": "Bob"}      |   pushes at
|        |<------------------------------|   will...
|        |                               |        |
|        |          [ ... ]              |        |
|        |                               |        |
|        | 5. Connection Drops / Error   |        |
|        |X - - - - - - - - - - - - - - X|        |
|        |                               |        |
|        | 6. Auto-Reconnects instantly  |        |
|        |------------------------------>|        |
+--------+                               +--------+
```
### Web Sockets

is not just another technique or work around no it is different protocol than HTTP (TCP Socket) so what happen is the Client send a request to server a normal HTTP protocol request but this time with a header called **Upgrade Request**, and if server support web sockets it will response with another header then after that the HTTP Request end and a channel is opened between the browser and server with TCP Socket Protocol and it remain opened until client or browser close it.
#### Why its better 
Lightweight, the HTTP Request contain headers with a lot of data that could reach 1KB unlike web sockets send headers data inside frames which size could be like 10 bytes.
### SignalR
The Problems That faces web socket signal R solve it like for example client does not support web socket
it consist of 
#### Connection Layer
it responable to:
- Manage connection channels
- Choosing between (websocket - sse - longpolling)
- Framing and Serialization
- Manage Connection Life Cycle
#### Hub Layer
it responable to work as a layer between the server and client to communicate with each other easily , the server can call a `JS` function in the browser and the browser can call a `C#` function in the server

