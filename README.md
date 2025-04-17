# SpaceShooterPro

I wrote this game just to discover Unity and game development platform.

---

- Player-controlled spaceship with laser and triple-shot powerup
- Randomly spawning enemies and powerups
- Lives system and game over logic

---

## Setup
1. **Requirements:**
   - [Unity](https://unity.com/) (recommended version: 2021.3 LTS or later)
   - .NET SDK for C# scripting

2. **Clone the Repository:**
   ```bash
   git clone https://github.com/finjener/space_shooter.git
   ```
Open in Unity

---

## Controls
- **Movement:** Arrow Keys or WASD
- **Fire:** Spacebar
- **Collect Powerups:** Fly into them

---

## Gameplay
- **Objective:** Survive as long as possible by destroying enemies and avoiding collisions.
- **Enemies:** Spawn at the top and move downward. Colliding with them costs a life.
- **Powerups:** Collect to gain temporary abilities (e.g., triple shot).
- **Lives:** You start with 3 lives. Game over when lives reach zero.

---

## Project Structure
```
SpaceShooterPro/
  ├── Assets/
  │   ├── Animations/
  │   ├── Audio/
  │   ├── Materials/
  │   ├── Prefabs/
  │   ├── Scenes/
  │   ├── Scripts/
  │   │   ├── Player.cs
  │   │   ├── Enemy.cs
  │   │   ├── Powerup.cs
  │   │   ├── SpawnManager.cs
  │   │   
  │   └── Sprites/
  ├── ProjectSettings/
  ├── README.md
  
```
