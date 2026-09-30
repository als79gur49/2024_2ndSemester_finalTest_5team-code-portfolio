# 기여 근거

권민혁은 UI, JSON 저장·불러오기, 사운드 구현과 팀 작업 통합을 담당했습니다. 다음 내용은 원본 GitHub 커밋과 diff를 검토한 결과입니다. 파일 최초 추가와 주요 수정은 기여 근거이며 파일 전체 독점 저작권의 보증이 아닙니다.

| 기능 | 근거 커밋 |
| --- | --- |
| JSON 책임 분리 | [7c6dc4a](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/7c6dc4a6f1e43224ffd6f557b449779588efb815) |
| 소환 UI 초기 구현 | [4a1be4a](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/4a1be4adb834a05336a6de00bb8de3fa2a190dfb) |
| 실제 골드·유닛 정보 통합 | [60a37e8](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/60a37e898404e9fd4152f14cba83eafdf257dca7) |
| StageManager·결과·저장 통합 | [903ed92](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/903ed92c35a74e095b0df9ea9fd0e88071ddc166) |
| 체력 UI | [7916921](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/7916921d679087c6b99788fbd66c844ca177b2fb) |
| 공격 타이밍 | [dee4237](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/dee423765af4ca11f345eaf2ef5823c63d127f5e) |

GameManager는 유지나 최초 추가 후 권민혁의 이벤트·저장 통합, GoldSystem은 유지나 최초 추가 후 권민혁의 UI 이벤트 통합이 있었습니다. UnitStats·UnitMove·MonsterUnitMove는 유지나 기반에 권민혁이 UI·사망 상태를 수정했습니다. UnitUI·StarsController는 권민혁 기반에 유지나의 수정이 있고, UnitSpawn의 주요 기여자는 유지나입니다. 나머지 포함 코드 후보의 최초 추가·주요 수정은 기존 감사에서 권민혁으로 확인됐습니다.

UnitUI의 최대 소환수 검사는 `if (true)` 상태이므로 구현 완료 기능으로 주장하지 않습니다. 사운드 담당 이력은 보존하되 제외한 SoundManager의 코드나 완성된 실행 결과를 이 사본으로 제시하지 않습니다.

박가민의 [018fb3b](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/018fb3bdc42ec016b44922b1066ca0ea06a81dea)는 기존 스크립트의 동일 blob 재통합이며 새 코드 작성으로 계산하지 않습니다. 기존 감사 범위는 5개 브랜치와 main 41커밋, 유지나 98커밋, 박가민 71커밋이며 커밋 수로 기여율을 산출하지 않습니다.

SoundManager의 유지나 추가 근거는 [8b090fd](https://github.com/als79gur49/2024_2ndSemester_finalTest_5team/commit/8b090fdd6e5b4093878fd6a9a4a24f32c8dc1f87)입니다. 파일 전체 제외와 출처 한계는 README의 출처와 권리 항목을 참고하세요. 그래픽 담당과 팀 리깅·애니메이션 작업은 독자 원화의 증명이 아닙니다.