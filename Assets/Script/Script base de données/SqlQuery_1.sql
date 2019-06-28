{
"rules": {
    ".read": true,
    ".write": true,
    "highscores": {
      ".read": true,
      ".indexOn": ["level", "time"],
      ".write": true,
      "$highscore":{
        ".validate": "newData.hasChildren(['name', 'level', 'time', 'date'])",
        "level": {
          ".validate": "newData.isNumber() && (!data.exists() || data.val() >= newData.val())"
        },
        "name": {
          ".validate": "newData.isString() &&
                         newData.val().length <= 30"
        },
        "time": {
          ".validate": "newData.isNumber()"
        },
        "date": {
          ".validate": "newData.isNumber() &&
                          newData.val() <= now"
        }
      }
    }
}
}