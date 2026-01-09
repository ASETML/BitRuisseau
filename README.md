# BitRuisseau

## App Config
Un fichier app.config est nécessaire pour se connecter au broker: voici à quoi il pourrait ressembler:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
   <add key="username" value="nom"/>
   <add key="password" value="pwd"/>
   <add key="host" value="broker.example.com"/>
</appSettings>
</configuration>

```