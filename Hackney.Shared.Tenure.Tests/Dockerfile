FROM mcr.microsoft.com/dotnet/core/sdk:6.0

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.Tenure.sln ./
COPY ./Hackney.Shared.Tenure/Hackney.Shared.Tenure.csproj ./Hackney.Shared.Tenure/
COPY ./Hackney.Shared.Tenure.Tests/Hackney.Shared.Tenure.Tests.csproj ./Hackney.Shared.Tenure.Tests/
COPY /nuget.config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./Hackney.Shared.Tenure/Hackney.Shared.Tenure.csproj
RUN dotnet restore ./Hackney.Shared.Tenure.Tests/Hackney.Shared.Tenure.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out Hackney.Shared.Tenure.Tests/Hackney.Shared.Tenure.Tests.csproj

CMD dotnet test
