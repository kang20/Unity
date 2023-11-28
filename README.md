## [해커톤] Unity_Repo

# 초기세팅
1. Assets 아래, 개인 Scene 및 필요한 폴더 세팅
폴더 내에 본인 폴더 만들어서 사용하기

2. Prefab 되어있는 오브젝트 삭제 및 수정
현재 Main_BackGround 같은 경우 Prefab 되어 자식 오브젝트를 포함한 모든 것들이 삭제가 안됨
삭제하고 싶으면 부모 Prefab인 'Main_BackGround' 우클릭 후 Prefab -> UnPack을 눌러 프리팹을 해제하고 삭제함
그러면 개인의 Main_BackGround가 수정됨 (공통으로 수정해야 한다면 프로젝트 Prefab 상태에서 수정)



# 유니티-깃허브 연동 방법
1. 아무 3D 프로젝트 생성
2. 원본 저장소 fork 후 본인 원격 저장소 링크 복사 후 '깃허브 데스크탑' FILE -> Clone Repo
3. 1번에서 생성한 디렉토리 내부의 파일을 모두 Clone Repo에 붙여넣음
4. 유니티 허브에서 '추가'를 눌러 Clone Repo를 열어준 후 작업 (1번 디렉토리 삭제)
5. 이후 Push와 PR 동일
