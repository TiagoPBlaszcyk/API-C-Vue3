# API

## Data Base
Start one DataBase MySQL, after
in API/appsettings.json
```
  "ConnectionStrings": {
    "DefaultConnection": "SET-YOUR-DATABASE-"
  }
```
Package Manager Console - add tables with
```
add-migration Start
after
update-database
```
** or **
Open Terminal on project paste
```
dotnet tool install --global dotnet-ef
after
dotnet ef migrations add Start
after
dotnet ef database update
```

##  Open Front-End
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).
