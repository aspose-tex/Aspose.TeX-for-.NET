# .NET API to TypeSet TeX Files

[![Nuget](https://img.shields.io/nuget/v/Aspose.Tasks)](https://www.nuget.org/packages/Aspose.TeX/) ![Nuget](https://img.shields.io/nuget/dt/Aspose.Tasks)

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/tex/net) | [Docs](https://docs.aspose.com/tex/net/) | [Demos](https://products.aspose.app/tex/family) | [API Reference](https://apireference.aspose.com/tex/net) | [Examples](https://github.com/aspose-tex/Aspose.tex-for-.NET) | [Blog](https://blog.aspose.com/category/tex/) | [Free Support](https://forum.aspose.com/c/tex) |  [Temporary License](https://purchase.aspose.com/temporary-license)

[Aspose.TeX for .NET](https://products.aspose.com/tex/net) is a library that provides a TeX engine extension called ObjectTeX. It can be used to typeset documents described by TeX files. “Object” means that intermediarytypesetting result is a specific object model which then can be uniformly converted into a number of end formats.

<p align="center">
<a title="Download complete Aspose.Tex for .NET source code" href="https://github.com/aspose-tex/Aspose.Tex-for-.NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Aspose.TeX.Examples](Aspose.TeX.Examples)  | A collection of .NET examples that help you learn the product features.

## TypeSetting File Processing Features

- Typesetting of TeX files
- Create custom TeX formats
- Provide input data in various ways
- Fetch output data in various ways

## Supported Input Formats

TeX

## Save TeX As

XPS, PDF, JPEG, PNG, TIFF and BMP

## Supported Embedded Fonts for Typesetting

cmbsy10, cmbx10, cmbx5, cmbx6, cmbx7, cmbx8, cmbx9, cmcsc10, cmdunh10, cmex10, cmmi10, cmmi5, cmmi6, cmm7, cmmi8, cmmi9, cmmib10, cmr10, cmr5, cmr6, cmr7, cmr8, cmr9, cmsl10, cmsl8, cmsl9, cmsltt10, cmss10, cmssbx10, cmssi10, cmssq8, cmssqi8, cmsy10, cmsy5, cmsy6, cmsy7, cmsy8, cmsy9, cmti10, cmti7, cmti8, cmti9, cmtt10, cmtt8, cmtt9, cmu10

## Supported Platforms

You can use Aspose.TeX for .NET to build any type of a 32-bit or 64-bit .NET application including ASP.NET, WCF, WinForms, WPF, etc.

## Use C# to Obtain Typeset Document from `XPS` Device

You can execute the below code snippet to see how Aspose.TeX API performs against your own samples or check the [GitHub Repository](https://github.com/aspose-tex/Aspose.TeX-for-.NET/tree/master/Aspose.TeX.Examples) for other common usage scenarios.

```csharp
TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
options.JobName = "sample2-1";
options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);
options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

using(Stream stream = File.Open(Path.Combine(_outputDirectory, options.JobName + ".xps"), FileMode.Create))
TeX.Typeset("hello-world", new XpsDevice(stream), options);

options.TerminalOut.Writer.WriteLine();
```

[Home](https://www.aspose.com/) | [Product Page](https://products.aspose.com/tex/net) | [Docs](https://docs.aspose.com/tex/net/) | [Demos](https://products.aspose.app/tex/family) | [API Reference](https://apireference.aspose.com/tex/net) | [Examples](https://github.com/aspose-tex/Aspose.tex-for-.NET) | [Blog](https://blog.aspose.com/category/tex/) | [Free Support](https://forum.aspose.com/c/tex) |  [Temporary License](https://purchase.aspose.com/temporary-license)
