FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.Tenure/Hackney.Shared.Tenure.csproj ./
COPY /nuget.config /root/.nuget/NuGet/NuGet.Config
RUN dotnet restore ./Hackney.Shared.Tenure.csproj

# Copy everything else and build
COPY ./Hackney.Shared.Tenure ./
RUN dotnet build -c Release -o out ./Hackney.Shared.Tenure.csproj
RUN dotnet publish -c Release -o out ./Hackney.Shared.Tenure.csproj

EXPOSE ${PORT:-3000}
CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/Hackney.Shared.Tenure.dll
