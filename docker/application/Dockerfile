ARG REPO=mcr.microsoft.com/dotnet/core/aspnet
FROM $REPO:2.2.5-alpine3.9

LABEL Bruno Hammerschmidt

WORKDIR /app
COPY ./app /app

EXPOSE 80

ENTRYPOINT ["dotnet", "MongoExample.Api.dll"]