# 피그 혁명 — 코드 검토용 사본

2024년 2학기 후기 프로젝트(2024.11–12), C#/Unity. 팀 코드 읽기와 포트폴리오 검토를 위한 부분 사본입니다.

기획 윤재헌, 프로그래밍 권민혁·유지나, 그래픽 박가민·정예은. 권민혁의 담당 범위는 UI, JSON 저장·불러오기, 사운드 구현, 팀원 작업 통합입니다. 구체적인 공동수정과 근거는 [CONTRIBUTIONS.md](CONTRIBUTIONS.md)를 확인하세요.

원본 private 저장소: `als79gur49/2024_2ndSemester_finalTest_5team`.
사용자가 선택한 유지나 브랜치의 12월 5일 통합본 고정 커밋: `7d8e92b8d6c8cd6814f307cc705c28eaf99bf92d`.
main의 12월 1일 기준본과 구분됩니다. private 커밋 링크는 접근 권한이 필요합니다.

## 읽는 방법과 제한

34개 C# 파일은 원래 상대경로에, 설정 문맥 3개는 `ReviewContext/` 아래에 보존했습니다. 이 사본은 실행·빌드할 수 없습니다. 씬, 프리팹, 리소스, meta와 대부분의 프로젝트 설정이 없으며, 제외한 SoundManager를 참조하는 코드도 해결되지 않은 채 남아 있습니다. ReviewContext는 참고용이며 패키지 설치나 Unity 프로젝트 실행을 위한 루트 설정이 아닙니다. 버그 수정과 UTF-8 변환을 하지 않았습니다. 원본 인코딩에 맞는 편집기로 읽으세요.

Unity `2022.3.7f1` (revision `b16b3b16c7a0`). 취득한 manifest/lock과 대조한 버전: TMP 3.0.6, uGUI 1.0.0, Visual Scripting 1.8.0, Burst lock 1.8.7, 2D feature 2.0.0, 2D Animation 9.0.3, PSD Importer 8.0.2, Timeline 1.7.5, Test Framework 1.1.33, Collab Proxy 2.5.2, Rider 3.0.24, Visual Studio 2.0.18.

## 포함 목록과 검증

아래 목록이 원본 파일의 exact allowlist입니다. 원본 452개 중 37개를 포함하고 415개를 제외했습니다. 생성 문서는 README.md, CONTRIBUTIONS.md, .gitignore, MANIFEST.csv, VALIDATION.json의 5개이며 총 42개 파일입니다.

모든 원본 파일의 고정 커밋, Git blob SHA, 크기, SHA256은 [MANIFEST.csv](MANIFEST.csv)에 기록했습니다. 정상적으로 전달된 텍스트를 인코딩 후보로 복원하고 원본 Git blob SHA와 크기가 모두 일치한 바이트만 채택했습니다. 저장 후 SHA256도 대조했습니다. 이는 인코딩 변경이 아닌 원본 바이트 복원입니다. 전체 파일 목록·민감정보·충돌 표식 검사 결과는 [VALIDATION.json](VALIDATION.json)에 있습니다.

- `Assets/Scripts/Character/GameManager.cs` → `Assets/Scripts/Character/GameManager.cs`
- `Assets/Scripts/Character/GoldSystem.cs` → `Assets/Scripts/Character/GoldSystem.cs`
- `Assets/Scripts/Character/MonsterUnitMove.cs` → `Assets/Scripts/Character/MonsterUnitMove.cs`
- `Assets/Scripts/Character/PlayAttackSound.cs` → `Assets/Scripts/Character/PlayAttackSound.cs`
- `Assets/Scripts/Character/StageManager.cs` → `Assets/Scripts/Character/StageManager.cs`
- `Assets/Scripts/Character/UnitAttackTiming.cs` → `Assets/Scripts/Character/UnitAttackTiming.cs`
- `Assets/Scripts/Character/UnitMove.cs` → `Assets/Scripts/Character/UnitMove.cs`
- `Assets/Scripts/Character/UnitSpawn.cs` → `Assets/Scripts/Character/UnitSpawn.cs`
- `Assets/Scripts/Character/UnitStats.cs` → `Assets/Scripts/Character/UnitStats.cs`
- `Assets/Scripts/SaveAndLoad/DataManager.cs` → `Assets/Scripts/SaveAndLoad/DataManager.cs`
- `Assets/Scripts/SaveAndLoad/JsonSaveAndLoader.cs` → `Assets/Scripts/SaveAndLoad/JsonSaveAndLoader.cs`
- `Assets/Scripts/SaveAndLoad/PlayerData.cs` → `Assets/Scripts/SaveAndLoad/PlayerData.cs`
- `Assets/Scripts/Sound/BGMManger.cs` → `Assets/Scripts/Sound/BGMManger.cs`
- `Assets/Scripts/Sound/OnButtonClickSound.cs` → `Assets/Scripts/Sound/OnButtonClickSound.cs`
- `Assets/Scripts/UI/ButtonClickLimit.cs` → `Assets/Scripts/UI/ButtonClickLimit.cs`
- `Assets/Scripts/UI/ButtonSlider.cs` → `Assets/Scripts/UI/ButtonSlider.cs`
- `Assets/Scripts/UI/ChangeImage.cs` → `Assets/Scripts/UI/ChangeImage.cs`
- `Assets/Scripts/UI/DefeatedPanel.cs` → `Assets/Scripts/UI/DefeatedPanel.cs`
- `Assets/Scripts/UI/FollowUI.cs` → `Assets/Scripts/UI/FollowUI.cs`
- `Assets/Scripts/UI/PanelController.cs` → `Assets/Scripts/UI/PanelController.cs`
- `Assets/Scripts/UI/QuitGame.cs` → `Assets/Scripts/UI/QuitGame.cs`
- `Assets/Scripts/UI/SceneLoader.cs` → `Assets/Scripts/UI/SceneLoader.cs`
- `Assets/Scripts/UI/ScriptPanel.cs` → `Assets/Scripts/UI/ScriptPanel.cs`
- `Assets/Scripts/UI/SettingPanel.cs` → `Assets/Scripts/UI/SettingPanel.cs`
- `Assets/Scripts/UI/StagePanel.cs` → `Assets/Scripts/UI/StagePanel.cs`
- `Assets/Scripts/UI/StarInfo.cs` → `Assets/Scripts/UI/StarInfo.cs`
- `Assets/Scripts/UI/StarsController.cs` → `Assets/Scripts/UI/StarsController.cs`
- `Assets/Scripts/UI/StopPanel.cs` → `Assets/Scripts/UI/StopPanel.cs`
- `Assets/Scripts/UI/UIBlocker.cs` → `Assets/Scripts/UI/UIBlocker.cs`
- `Assets/Scripts/UI/UpdateHealthText.cs` → `Assets/Scripts/UI/UpdateHealthText.cs`
- `Assets/Scripts/UI/VictoryPanel.cs` → `Assets/Scripts/UI/VictoryPanel.cs`
- `Assets/Scripts/UI/Stage/PopupMessage.cs` → `Assets/Scripts/UI/Stage/PopupMessage.cs`
- `Assets/Scripts/UI/Stage/UnitUI.cs` → `Assets/Scripts/UI/Stage/UnitUI.cs`
- `Assets/Scripts/UI/Stage/UpdateGold.cs` → `Assets/Scripts/UI/Stage/UpdateGold.cs`
- `Packages/manifest.json` → `ReviewContext/Packages/manifest.json`
- `Packages/packages-lock.json` → `ReviewContext/Packages/packages-lock.json`
- `ProjectSettings/ProjectVersion.txt` → `ReviewContext/ProjectSettings/ProjectVersion.txt`

## 제외 범위

서로 겹치지 않는 분류로 집계했으며, meta는 원래 에셋 종류와 별도로 계산했습니다. TMP vendor가 폰트·머티리얼 등보다 우선하는 분류입니다. 제외 파일의 개별 이름·개인경로는 열거하지 않습니다.

| 종류 | 제외 개수 |
| --- | ---: |
| 기타 | 4 |
| 메타데이터 | 227 |
| 음원 | 11 |
| 이미지·PSB | 37 |
| 폰트·SDF | 3 |
| 기타 JSON | 1 |
| 프리팹 | 37 |
| 씬 | 8 |
| 제외 C# | 5 |
| TMP vendor | 32 |
| 애니메이션 | 26 |
| 기타 프로젝트 설정 | 24 |

폰트/SDF/이미지/음원/애니메이션/PSB/씬/프리팹/머티리얼/meta/vendor TMP/런타임 저장 JSON을 포함하지 않습니다. 제외 C# 5개는 출처 보류 사운드 관리자, 사용중지 코드 3개, 개발용 캡처 코드 1개입니다. 원본 .git·history도 포함하지 않습니다.

## 출처와 권리

사용자는 팀 코드와 이름의 공개 동의를 확인했습니다. 사용자는 이 코드 검토용 사본의 공개·업로드를 승인했습니다. 새 OSS 라이선스를 부여하지 않습니다. 팀 코드 전체의 독점 저작이나 외부 차용 부재를 보증하지 않습니다.

원본 저장소와 외부 에셋을 대조한 결과에 따르면 UI PNG 10개는 LayerLab GUI Pro Simple Casual을 포함한 다른 두 저장소와 동일 blob이고, 외부 군사기지 아이콘은 Flaticon의 juicy_fish, Military base ID 6753907과 동일 bytes입니다. 캐릭터 PSB 6개는 팀 리깅·애니메이션 작업 근거이나 독자 원화임을 확정하지 못합니다. 출처 미확인 늑대 이미지, Tmoney Round Wind Extra Bold·TMP Liberation Sans·EmojiOne과 외부 음원도 제외했습니다. 이 사본은 에셋 내용을 취득하거나 재배포하지 않습니다.

SoundManager는 공개 AudioManager 샘플과 유사한 멀티채널 부분의 출처를 확인할 수 없어 파일 전체를 보류했습니다. 유사성만으로 복사·침해를 단정하지 않습니다.