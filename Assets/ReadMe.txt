Undead - 10:42 episode 6 Spawn doanh trai

Unity Tilemap & Rule Tile, 13:00 Title map layer

Layers plan:
1 - Ground
2 - WalkInfront
3 - Collision
3.5 - Player
4 - WalkBehind
5 - Decor

Scale kích thước firePoint
Tự động xóa sau khi đã hết animation
timer += Time.deltaTime
if(timer > ...) Destroy(gameObject)
Chỉ gọi SkillEffect khi đứng trong tầm

Time of float để spawn theo thời gian, cái này nằm trong Update()
Instantiate, roatate
Vector2 direction
Viên đạn sẽ bay theo hướng player nhưng có cố định 1 vòng tròn chứ không phải theo enemy

Cần chơi thử và xác định vị trí về con số

Bullet trả về hướng quay prefabs, rotation,... 

Trong tầm thì dùng dùng if và 1 biến distance để xác định

BoxCollider2D làm xác định bị tấn công
collider.gameObject.GetComponent<playerHealth>().health -=20;