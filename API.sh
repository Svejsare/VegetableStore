#!/bin/bash
cd VegetableWarehouse
dotnet build
dotnet publish -c release -r win-x64
./bin/Release/netcoreapp3.1/win-x64/publish/VegetableWarehouse.exe