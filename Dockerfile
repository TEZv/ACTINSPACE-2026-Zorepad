# Етап 1: Збірка (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо все в контейнер
COPY . .

# Знаходимо всі .csproj і відновлюємо залежності
# (Це магія, яка працює навіть якщо у тебе складна структура)
RUN dotnet restore

# Збираємо проєкт у папку /app/publish
# ВАЖЛИВО: Якщо у тебе кілька проєктів, Railway може зібрати не той.
# Ця команда збере той, який знайде.
RUN dotnet publish -c Release -o /app/publish

# Етап 2: Запуск (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Тут треба вказати ім'я твого DLL файлу!
# Зазвичай це назва твого проєкту + .dll
# Наприклад, якщо файл проєкту Zorepad.csproj, то тут буде Zorepad.dll
ENTRYPOINT ["dotnet", "ACTINSPACE-2026-Zorepad.dll"] 
