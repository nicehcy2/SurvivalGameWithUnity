
<div align="center">
  <h2>[2023] Undead Survival Game</h2>
  좀비 아포칼립소에서 생존하는 게임, Undead Survival Game입니다!<br> 플레이어에게 접근하는 좀비들을 처치해 얻은 경험치로 레벨을 쌓아 보스 몹을 제거하는 게임입니다. <br> 이 게임은 Unity와 Git 공부를 위해 제작했기에 인게임 중 사소한 버그들이 있으며 "골드 메탈"님의 에셋을 사용했습니다.
</div>

## 목차
  - [개요](#개요)
  - [게임 설명](#게임-설명)
  - [스킬 설명](#스킬-설명)
  - [아이템 설명](#아이템-설명)
  - [스킬 업그레이드 설명)(#스킬-업그레이드-설명)
  - [게임 플레이 방식](#게임-플레이-방식)
  - [버그 확인](#버그-확인)

## 개요
  - 프로젝트 이름: Undead Survival Game
  - 프로젝트 지속 기간 : 2023.01.31 - 2023.08.12
  - 게임 엔진 및 언어 : Unity & C#
  - 멤버 : 허찬영, 장세영

## 게임 설명
<img width="480" alt="MainTitle" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/17f21d09-a635-4f89-9403-dabc7dc108d1"> <br>
메인 화면 페이지에서 "New Game Start" 버튼을 누르면 게임이 시작됩니다. 게임의 규칙은 다음과 같습니다.<br>
- 플레이어는 원거리 타입, 근접 타입 중 하나의 스킬을 선택할 수 있습니다. <br>
- 스폰한 좀비들은 플레이어에게 접근하며 공격합니다. 플레이어는 어디로 도망가든 좀비를 따돌리지 못합니다. 스킬과 아이템을 활용해서 좀비를 잡으세요 <br>
- 아이템은 총 5개로 플레이어 주변에 랜덤으로 스폰됩니다. 
- 좀비를 처치하면 경험치를 드랍합니다. 경험치를 얻고 레벨을 올리면 스킬 혹은 플레이어의 스탯을 강화 시킬 수 있습니다. <br>
- 플레이어의 레벨이 MAX가 되면 (11레벨) 보스가 출현합니다. 보스를 잡고 게임을 클리어하세요! <br>

## 스킬 설명
|스킬|근거리 스킬|원거리 스킬|
|---|---|---|
|Icon|<img width="95" alt="Melee" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/2f6daf21-a8dc-4f9f-bb63-1e1b38f50e9a">|<img width="95" alt="RangeSkill" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/200c4f39-ea5f-4867-b318-56effc15f4fc">|<br><br>

<img width="480" alt="MeleeSkillPlay" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/86a6cf0e-d9d0-4c03-8afd-0241100ef378"><br>
- 근거리 스킬: 플레이어 주위로 근접 스킬이 회전하여 좀비를 공격합니다.<br>

<img width="480" alt="RangeSkillPlay" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/00f2e581-718a-4b9e-ba6b-9babccf0d49d"><br>
- 원거리 스킬: 플레이어와 가장 가까이에 있는 좀비에게 원거리 스킬을 시전합니다.<br>

## 아이템 설명
|아이템|Health Pack|Boost|Adrenaline|Magnet|Bomb|
|---|---|---|---|---|---|
|Image|<img width="50" alt="HealthPack" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/ec3b931b-20b4-4686-974e-a599526cf56e">|<img width="50" alt="BoostItem" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/36317c9e-42d6-4783-9bd7-7deeb9cb133f">|<img width="50" alt="AdrenalineItem" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/bcd01a4c-36db-4989-a491-bd8e8a2b1478">|<img width="50" alt="MagnetItem" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/839346f6-9f8f-45a7-bbdf-df56fb350092">|<img width="50" alt="BombItem" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/f01116f5-cfdd-4ec3-91e5-72245b72791f">|<br>

- Health Pack: 체력을 5 회복합니다.
- Boost: 3초 동안 플레이어의 스킬 데미지와 이동 속도가 증가합니다.
- Adrenaline: 5초 동안 플레이어의 스킬 데미지와 이동 속도가 매우 증가하지만 체력이 5 감소합니다.
- Magnet: 자석 능력 범위 안에 있는 경험치를 얻을 수 있습니다.
- Bomb: 1초 동안 강력한 범위 공격을 합니다.

## 스킬 업그레이드 설명
|업그레이드|Damage|Count|Health|Speed|
|---|---|---|---|---|
|Image|<img width="50" alt="SkillDamageUpgrade" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/d949cd25-5f6e-4f02-8512-d28dd43cc427">|<img width="50" alt="SkillCountDamage" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/2d3aec50-03cf-49a2-9b29-dc6969eaffd8">|<img width="50" alt="HealthPack" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/b4d0b63c-862e-4dcb-86ff-93004b33e999">|<img width="50" alt="PlayerSpeedUpgrade" src="https://github.com/nicehcy2/SurvivalGameWithUnity/assets/105339362/8d83ab61-b5e8-41f8-a4e7-f500413221b5">|<br>

- Damage: 스킬의 데미지를 강화합니다.
- Count: 원거리 스킬일 경우 스킬의 장전 속도를, 근거리 스킬일 경우 스킬의 수를 증가합니다.
- Health: 플레이어의 체력을 회복합니다.(별로 안좋음)
- Speed: 플레이어의 이동 속도를 증가합니다. 

## 게임 플레이 방식
- 플레이어 이동키

|이동방향|상(위)|좌(왼쪽)|하(아래)|우(오른쪽)|
|---|---|---|---|---|
|방향키|⬆️|⬅️|⬇️|➡️|

- 아이템 조작키

|1번 아이템|2번 아이템|
|---|---|
|❶|❷|

## 버그 확인
- 가끔 맵 이동 시 로딩이 안되는 버그가 있다 



