# Project Base

> 개인 Unity 게임 프로젝트의 초기 설정에 재사용하는 씬·스크립트·프리팹 모음입니다.

새 프로젝트마다 반복하는 기본 구성을 모아 두었습니다. **전체 Unity 프로젝트가 아닌 에셋 모음**으로, 사용할 프로젝트의 `Assets` 폴더에 필요한 파일을 옮겨 적용합니다.

## 폴더 구성

| 폴더 | 내용 | 적용 위치 |
| --- | --- | --- |
| [Scenes](Scenes) | 기본 스크립트와 프리팹이 배치된 씬 | `Assets/Scenes` |
| [Scripts/AD_Library](Scripts/AD_Library) | 공통 기능과 확장용 유틸리티 | `Assets/Scripts/AD_Library` |
| [Scripts/Managers](Scripts/Managers) | 데이터·리소스·씬·사운드·풀·팝업 등 관리 코드 | `Assets/Scripts/Managers` |
| [Objects](Objects) | 로그인, 로딩, 조이스틱, 스크롤 뷰 등 프리팹 | `Assets/Objects` |
| [ETC](ETC) | Android 언어별 앱 이름 리소스 등 | 내부 경로에 맞게 배치 |

### 기본 씬

| 씬 | 용도 |
| --- | --- |
| [Login.unity](Scenes/Login.unity) | PlayFab·Google 로그인 |
| [Main.unity](Scenes/Main.unity) | 로그인 이후 게임 진입 전 화면 |
| [Game.unity](Scenes/Game.unity) | 인게임 |
| [NextScene.unity](Scenes/NextScene.unity) | 씬 전환 |
| [Test.unity](Scenes/Test/Test.unity) | 기능 테스트 |

## 프로젝트에 적용하기

1. 저장소를 복제합니다.

   ```bash
   git clone https://github.com/ChoiDaeYoung-94/project-base.git
   ```

2. `Scenes`, `Scripts`, `Objects` 폴더를 사용할 Unity 프로젝트의 `Assets` 아래에 배치합니다.
3. `ETC`의 파일은 내부 경로에 맞춰 옮깁니다. 예를 들어 `ETC/Plugins/Android/res`는 `Assets/Plugins/Android/res`에 배치합니다.
4. 필요한 외부 라이브러리를 추가하고, 사용하는 로그인·광고·결제 기능의 설정을 프로젝트에 맞게 조정합니다.

**파일을 옮길 때는 함께 제공된 `.meta` 파일도 복사합니다.** 씬과 프리팹의 참조를 유지하는 데 필요합니다.

## 외부 의존성

기존 설정 안내에서 별도 추가 대상으로 명시한 라이브러리입니다.

- [MiniJSON.cs](https://gist.github.com/darktable/1411710)
- [PlayFab SDK](https://learn.microsoft.com/ko-kr/gaming/playfab/sdks/unity3d/installing-unity3d-sdk)
- [In-game Debug Console](https://assetstore.unity.com/packages/tools/gui/in-game-debug-console-68068)

로그인·광고·결제 관련 매니저를 사용할 경우 해당 SDK와 서비스 설정도 필요합니다. 이 저장소에는 Unity 버전을 지정하는 `ProjectSettings`가 없으므로, 적용할 프로젝트에서 의존성과 호환성을 확인합니다.

프리팹별 설명은 [Objects/readme.txt](Objects/readme.txt)와 각 하위 폴더의 `readme.txt`를 참고합니다.
