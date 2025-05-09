﻿
using Microsoft.AspNetCore.Builder;
using UFX.Relay.Tunnel;
using UFX.Relay.Tunnel.Forwarder;
using UFX.Relay.Tunnel.Listener;

Console.WriteLine(@"

 ██████╗██╗     ██╗███████╗███╗   ██╗████████╗     █████╗  ██████╗  ██████╗ 
██╔════╝██║     ██║██╔════╝████╗  ██║╚══██╔══╝    ██╔══██╗██╔════╝ ██╔════╝ 
██║     ██║     ██║█████╗  ██╔██╗ ██║   ██║       ███████║██║  ███╗██║  ███╗
██║     ██║     ██║██╔══╝  ██║╚██╗██║   ██║       ██╔══██║██║   ██║██║   ██║
╚██████╗███████╗██║███████╗██║ ╚████║   ██║       ██║  ██║╚██████╔╝╚██████╔╝
 ╚═════╝╚══════╝╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝       ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ 
                                                                                                                                                                      

    UFX.Relay Sample On-Prem Aggregate started
");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.AddTunnelListener(includeDefaultUrls: true);
builder.Services.AddTunnelClient(options =>
{
    options.TunnelHost = "wss://localhost:7400";
    options.TunnelId = "123";
});
var app = builder.Build();

app.MapGet("/", () => builder.Environment.ApplicationName);
app.MapGet("/client", () => "Hello from Client");
await app.RunAsync();