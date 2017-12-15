import socket 

UDP_IP = "127.0.0.1" # match IP address with C# program

UDP_PORT = 5005 # match up port with C# program

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # Internet, UDP

sock.bind((UDP_IP, UDP_PORT))

while True:
  data, addr = sock.recvfrom(1024) # buffer size is 1024 bytes
  print("received message: ", data)