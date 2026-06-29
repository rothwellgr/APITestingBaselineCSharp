FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /workspace

COPY APITestingBaselineCSharp.csproj .
RUN dotnet restore

COPY . .
RUN dotnet build -c Debug --no-restore

CMD ["bash"]
