# MakeGather

# 게더타운 만들기 - 김민태
# 구현 목록
- 캐릭터 생성
- 이름 설정
- 캐릭터 이동
- 애니메이션 설정
- 방 만들기
- 카메라 따라가기
- 참석 인원 UI
- 인게임 캐릭터 설정, 이름 변경
- 시간 표시
- NPC 대화

# 게임 시연
https://drive.google.com/file/d/1lERRd3jn2Z3rTZt6CuL9iCwrqTgjFcXA/view?usp=sharing

# 캐릭터 생성 씬
![생성 씬](https://github.com/rlaalsxo/MakeGather/assets/100994140/33a7e36c-8f2b-43b2-a89b-2e2b662e41c1)
- 캐릭터와 이름을 설정하여 게임을 시작할 수 있습니다.

# 게임 씬
![게임 씬](https://github.com/rlaalsxo/MakeGather/assets/100994140/d18d621c-43d1-4935-b1c4-fa4b1a76afde)
- 게임 씬 입니다. 그리드를 이용하여 씬을 만들었습니다.
- 벽은 collider 컴포넌트를 추가하여 넘어가지 못하게 하였습니다.
- 각각의 UI들은 이름대로 캐릭터 변경, 이름 변경, 유저 이름 표시를 해두었으며 껐다 켰다 할 수 있습니다.
- 왼쪽 상단에는 현재 시각이 표시되도록 하였습니다.

# NPC대화
![NPC대화](https://github.com/rlaalsxo/MakeGather/assets/100994140/8eb97c68-e116-4a70-9afc-6d4abb9e65b1)
- 거리를 비교해서 가까워지면 대화창이 뜨도록 했습니다.
- StartTalk버튼을 누를시 대화가 시작됩니다.
- 멀어지면 저절로 대화창이 사라집니다.

