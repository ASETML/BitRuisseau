# Protocole BitRuisseau
## Structure
Voici à quoi ressemble les messages envoyés sur le broker MQTT. Chaque requête est composé de 3 top-levels obligatoires: 
- ``version``: la version du protocole
    - ``a`` ou ``b``: a -> cmid3a, b -> cmid3b
- ``hosts``: les machines impliquée
    - ``dest``: le destinataire du message (0.0.0.0 si tout le monde)
    - ``em``: l'émetteur du message
- ``action``: pourquoi ce message ?
    - ``online``: message "je suis en ligne"
    - ``askCatalog``: demande le catalogue d'une médiathèque
    - ``sendCatalog``: envoie le catalogue de chanson à une autre médiathèque
    - ``askMedia``: demande une chanson à une médiathèque
    - ``sendMedia``: envoie une chanson à une médiathèque

et 1 top-level optionnel:
- ``params``: paramètre de l'action
    - ``songs``: Une liste de métadonnées de fichiers audios (sans le fichier audio, voir ISong)
    - ``sb``: Le bit de début
    - ``eb``: Le bit de fin
    - ``data``: Un tableau de bits entre sb et eb dans le fichier audio

## Exemple de messages
### Say online
```json
{
    "version": "b",
    "hosts": {
        "dest": "ip",
        "em": "ip"
    },
    "action": "online"
}
```

### AskCatalog
```json
{
    "version": "b",
    "hosts": {
        "dest": "ip",
        "em": "ip"
    },
    "action": "askCatalog"
}
```

### SendCatalog
```json
{
    "version": "b",
    "hosts": {
        "dest": "ip",
        "em": "ip"
    },
    "action": "sendCatalog",
    "params": {
        "songs": []
    }
}
```

### AskMedia
```json
{
    "version": "b",
    "hosts": {
        "dest": "ip",
        "em": "ip"
    },
    "action": "askMedia",
    "params": {
        "sb": 1,
        "eb": 2
    }
}
```

### SendMedia
```json
{
    "version": "b",
    "hosts": {
        "dest": "ip",
        "em": "ip"
    },
    "action": "sendMedia",
    "params": {
        "sb": 1,
        "eb": 2,
        "data": []
    }
}