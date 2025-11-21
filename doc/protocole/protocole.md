# Protocole BitRuisseau
## Structure
Voici à quoi ressemble les messages envoyés sur le broker MQTT (topic: BitRuisseau).
- ``Recipient``: le destinataire du message (0.0.0.0 si tout le monde, hostname sinon)
- ``Sender``: l'émetteur du message (hostname)
- ``Action``: pourquoi ce message ?
    - ``askOnline``: demande quelles médiathèques sont en ligne
    - ``online``: message "je suis en ligne"
    - ``askCatalog``: demande le catalogue d'une médiathèque
    - ``sendCatalog``: envoie le catalogue de chanson à une autre médiathèque
    - ``askMedia``: demande une chanson à une médiathèque
    - ``sendMedia``: envoie une chanson à une médiathèque
- ``SongList``: Une liste de métadonnées de fichiers audios (sans le fichier audio, voir ISong)
- ``StartByte``: Le bit de début
- ``EndByte``: Le bit de fin
- ``SongData``: Un tableau de bits encodé en base64 entre sb et eb dans le fichier audio
- ``Hash``: Le hash (SHA256) du fichier demandé / envoyé

## Exemple de messages
### Ask online
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"askOnline","StartByte":null,"EndByte":null,"SongList":null,"SongData":null,"Hash":null}
```

### Say online
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"online","StartByte":null,"EndByte":null,"SongList":null,"SongData":null,"Hash":null}
```

### AskCatalog
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"askCatalog","StartByte":null,"EndByte":null,"SongList":null,"SongData":null,"Hash":null}
```

### SendCatalog
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"askMedia","StartByte":null,"EndByte":null,"SongList":"list de ISong","SongData":null,"Hash":null}
```

### AskMedia
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"askMedia","StartByte":0,"EndByte":10,"SongList":null,"SongData":null,"Hash":"SHA256"}
```

### SendMedia
```json
{"Recipient":"0.0.0.0","Sender":"ME","Action":"askMedia","StartByte":0,"EndByte":10,"SongList":null,"SongData":"base64 encoded string","Hash":"SHA256"}
```