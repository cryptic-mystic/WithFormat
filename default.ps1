properties {

    $project = "WithFormat"
    $configuration = 'Release'
    $src = resolve-path '.\'
}

task default -depends Test

task Test -depends Compile {
    exec { packages\NUnit.Runners.2.6.3\tools\nunit-console.exe UnitTests\bin\$configuration\UnitTests.dll /framework=net-4.5 /nodots /xml=unittests.xml /trace=Verbose }
}

task Compile {
    exec { msbuild /t:clean /v:q /nologo /p:Configuration=$configuration $src\$project.sln }
    exec { msbuild /t:build /v:q /nologo /p:Configuration=$configuration $src\$project.sln }
}