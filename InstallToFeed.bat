@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
pause
c:\exe\nuget add .\Cadmus.Archive.Parts\bin\Debug\Cadmus.Archive.Parts.2.2.16.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Core\bin\Debug\Cadmus.Core.2.2.16.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Lexicon.Parts\bin\Debug\Cadmus.Lexicon.Parts.2.2.17.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Mongo\bin\Debug\Cadmus.Mongo.2.2.19.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Parts\bin\Debug\Cadmus.Parts.2.2.21.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Philology.Parts\bin\Debug\Cadmus.Philology.Parts.2.2.21.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed\bin\Debug\Cadmus.Seed.1.0.18.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Parts\bin\Debug\Cadmus.Seed.Parts.1.0.21.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Philology.Parts\bin\Debug\Cadmus.Seed.Philology.Parts.1.0.19.nupkg -source C:\Projects\_NuGet
pause
