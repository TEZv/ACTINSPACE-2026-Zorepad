// See https://aka.ms/new-console-template for more information


using Grpc.Net.Client;
using Zorepad_ACTINSPACE_2026_project;



Console.WriteLine("Hello, World!");
Console.ReadLine();
var input = new HelloRequest{Name = "Our Message"};

using var channel = GrpcChannel.ForAddress("http://localhost:5284");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(input);

Console.WriteLine("Bye, World!");
