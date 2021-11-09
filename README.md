# Analogy.AspNetCore.LogProvider       <img src="./Assets/icon.png" align="right" width="155px" height="155px">

<p align="center">

![.NET Core Desktop](https://github.com/Analogy-LogViewer/Analogy.AspNetCore.LogProvider/workflows/.NET%20Core%20Desktop/badge.svg) 
<a href="https://github.com/Analogy-LogViewer/Analogy.AspNetCore.LogProvider/issues">
    <img src="https://img.shields.io/github/issues/Analogy-LogViewer/Analogy.AspNetCore.LogProvider" img alt="Issues"/>
</a>
![GitHub closed issues](https://img.shields.io/github/issues-closed-raw/Analogy-LogViewer/Analogy.AspNetCore.LogProvider)
<a href="https://github.com/Analogy-LogViewer/Analogy.AspNetCore.LogProvider/blob/master/LICENSE.md">
    <img src="https://img.shields.io/github/license/Analogy-LogViewer/Analogy.AspNetCore.LogProvider" img alt="License"/>
</a>
 [![Nuget](https://img.shields.io/nuget/v/Analogy.AspNetCore.LogProvider)](https://www.nuget.org/packages/Analogy.AspNetCore.LogProvider/)
</p>

Custom logging provider in Asp.Net Core that write logs to Analogy Log Server



## Usage

Add Nuget package [Analogy.AspNetCore.LogProvider](https://www.nuget.org/packages/Analogy.AspNetCore.LogProvider/) and then add to the Configure method the following in te Startup.cs

```csharp

 public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
 {
     loggerFactory.AddAnalogyLogger(new AnalogyLoggerConfiguration
     {
         LogLevel = LogLevel.Trace,
         EventId = 0,
         AnalogyServerUrl = "http://localhost:6000"
      });
     }

```

