# About

개인 게임 프로젝트를 시작할 때 초기 세팅을 편하게 하기 위한 Assets을 관리하는 저장소

## About directory files

### Scenes

게임 프로젝트에서 사용하는 기본 scene을 관리한다.  
각 scene에는 기본적으로 필요한 스크립트나 프리팹이 이미 배치되어 있다.  
해당 폴더는 게임 프로젝트의 Assets 아래 위치한다.

- Test
  - Test.unity
  - 작업 테스트 시 사용하는 scene
- Game.unity
  - Ingame scene
- Login.unity
  - Playfab, Google login scene
- Main.unity
  - Login scene에서 login 이후 Game scene 들어가기 전 scene
- NextScene.unity
  - scene 전환 시 사용하는 scene

### Scripts

게임 프로젝트에서 사용하는 기본 script를 관리한다.  
해당 폴더는 게임 프로젝트의 Assets 아래 위치한다.

- DY_Library
  - 작업 시 바로 사용 및 확장이 가능한 스크립트가 존재한다.
  - 해당 폴더의 readme.txt에 간략한 설명이 있다.
- Managers
  - 매니저 역할을 하는 스크립트가 존재한다.
  - 해당 폴더의 readme.txt에 간략한 설명이 있다.

### Objects

게임 프로젝트에서 바로 사용 가능한 Prefab을 관리한다.  

### ETC

이미 지정이 되어있는 폴더나 위 폴더에 속하지 않는 내용들을 관리한다.  
해당 폴더의 readme.txt에 간략한 설명이 있다.

## Project settings

1. 본 repo의 Scenes, Scripts, Objects 폴더를 Assets 폴더 아래에 위치한다.
2. ETC 폴더의 경우 ETC 안의 폴더들의 이름이 경로이며 그에 맞게 위치한다.
3. 본 프로젝트에 포함되지 않지만 필요한 내용들을 따로 추가해야 한다.
    - [MiniJSON.cs](https://gist.github.com/darktable/1411710)
    - [playfab sdk](https://learn.microsoft.com/ko-kr/gaming/playfab/sdks/unity3d/installing-unity3d-sdk)
    - [Debug Console](https://assetstore.unity.com/packages/tools/gui/in-game-debug-console-68068)

