// ITNOA

#tool "nuget:?package=NUnit.ConsoleRunner&version=3.11.1"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
{
	CleanDirectory("Build/Artifacts");
	MSBuild("PrismExample.sln", new MSBuildSettings().WithTarget("clean"));
});

Task("Restore")
	.Does(() =>
{
	MSBuildSettings settings = new MSBuildSettings
	{
		ArgumentCustomization = args => args.Append("-ignoreProjectExtensions:.vdproj")
			.Append("-p:RestoreUseSkipNonexistentTargets=false")
			.Append("-p:RestorePackagesConfig=true"),
	};

	MSBuild("PrismExample.sln", settings.WithTarget("restore"));
});

Task("Build")
	.IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
	MSBuildSettings settings = new MSBuildSettings
	{
		Configuration = configuration,
		Verbosity = Verbosity.Normal,
		MSBuildPlatform = MSBuildPlatform.x86,
		PlatformTarget = PlatformTarget.MSIL,
		MaxCpuCount = 8,
	};

	MSBuild("PrismExample.sln", settings);
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
	string resultFile = "Build/Artifacts/TestResult.xml";
	var settings = new NUnit3Settings
	{
		Configuration = configuration,
		HandleExitCode = _ => true,
		Results = new[]
		{
			new NUnit3Result
			{
				FileName = resultFile
			}
		}
	};

	NUnit3(@"Tests\UnitTests\PrismExample.ClassLibrary1.Tests\bin\Debug\netcoreapp3.1\PrismExample.ClassLibrary1.Tests.dll", settings);
});

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
{
});

Task("Default")
	.IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
	.IsDependentOn("Publish");

	
Task("JustBuild")
	.IsDependentOn("Clean")
	.IsDependentOn("Build");
	
Task("JustTest")
	.IsDependentOn("Clean")
	.IsDependentOn("Test");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
