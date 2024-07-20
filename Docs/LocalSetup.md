# Local Setup

## `appsettings.Development.json`

- Clone the `template.appsettings.Development.json` configuration file and remove the `template` part.
- Add local setup keys/secrets to the `appsettings.Development.json`.

## Firebase setup

- Go to [Firebase Console](https://console.firebase.google.com/u/0/) and set up your demo project.
- CLick the gear icon in the Project Overview > Project settings > Service accounts tab > Generate new private key.
- Save the key to a folder of your choice and copy the path to it.
- Add the path as a value with a key for example `FireBasePrivateKeyPathEnvironmentVar` inside the `appsettings.Development.json`

