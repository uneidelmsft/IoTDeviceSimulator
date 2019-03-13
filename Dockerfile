

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ./*.csproj .
RUN dotnet restore
COPY . /src
RUN dotnet publish  -c release  -o output


FROM microsoft/dotnet:2.2-runtime AS runtime
COPY --from=build /src/output .

#FROM microsoft/dotnet:2.2-runtime AS runtime
#COPY --from=build src/bin/release/netcoreapp2.2/ app
#WORKDIR /app
ENTRYPOINT ["dotnet", "IoTDeviceSimulator.dll"]



