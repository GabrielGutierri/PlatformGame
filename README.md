# 🎮 PlatformGame

A Windows desktop platform game developed in **C# / Windows Forms (.NET Framework 4.7.2)**, featuring a main platformer level that unlocks three embedded mini-games. The player navigates the level collecting keys that open doors, each leading to a different mini-game challenge. Completing all three wins the game.

---

## 🕹️ Gameplay Overview

The player controls a character called **Wuo** through a scrolling platform level. The objective is to collect three keys scattered across the level and bring each one to the corresponding locked door. Each door opens a mini-game that must be completed to progress. After all three mini-games are cleared, the player wins.

The main level features platforms, lava hazards, an enemy that patrols and shoots lasers, collectible coins for score, and a lives system tied to difficulty. The character can run, jump, and fire lasers in both directions.

---

## 🎯 Mini-games

### 🛸 Calculus Invaders
A Space Invaders-style mini-game where the player shoots down waves of enemies (themed around calculus concepts — derivatives). The player can move left/right and fire upward. Enemies fire back periodically. Clearing all enemies wins the round.

### 🦕 Dino Game
A Chrome-style endless runner where Wuo must jump over incoming obstacles. Obstacle speed increases over time. The player presses a key to jump and must survive as long as possible. Runs until death or reaching a score threshold.

### 🏓 Pong
A single-player Pong mini-game against an AI-controlled opponent. The player controls a paddle with arrow keys and must beat the computer to a set number of points. Ball speed is tied to the difficulty setting.

---

## ✨ Features

- Scrolling platform level with physics (gravity, jumping, collision detection per tag)
- Player laser shooting in both directions (left/right)
- Enemy with patrol AI and periodic laser fire
- 3 collectible keys → 3 locked doors → 3 mini-games
- Difficulty settings (Easy / Normal / Hard) affecting lives, enemy fire rate, and Pong ball speed
- Immunity frames after taking damage (flashing character effect)
- Global score and ranking system (`frmRanking`)
- Options screen with music/sound on-off toggle (`clsConfig`)
- Cut scene on game start (`frmCutScene`)
- Tutorial screens before each mini-game
- Background music and sound effects via `WMPLib.WindowsMediaPlayer`

---

## 🗂️ Project Structure

```
PlatformGame/
└── jogoN2v2.0/
    ├── Constants/              # Game constants per screen (speeds, tags, strings)
    │   ├── MainGameConstants.cs
    │   ├── DinoGameConstants.cs
    │   ├── PongConstants.cs
    │   ├── CalculusInvadersConstants.cs
    │   ├── ConfigurationConstants.cs
    │   └── ...
    ├── Utils/
    │   └── GameUtils.cs        # Shared utilities (e.g. PlayTrack helper)
    ├── clsConfig.cs            # Global config state (difficulty, music, points)
    ├── frmPrincipal.cs         # Main menu
    ├── frmMainGame.cs          # Main platformer level + game loop
    ├── frmCalculusInvaders.cs  # Space Invaders mini-game
    ├── frmDinoGame.cs          # Dino runner mini-game
    ├── frmPong.cs              # Pong mini-game
    ├── frmGameOver.cs          # Game over / win screen
    ├── frmRanking.cs           # Ranking / high score screen
    ├── frmOptions.cs           # Sound and music settings
    ├── frmHelp.cs              # Help screen
    ├── frmCutScene.cs          # Intro cut scene
    ├── frmLoadingGame.cs       # Loading screen
    ├── frmTutorial*.cs         # Tutorial screens for each mini-game
    ├── images/                 # Sprites and backgrounds per game section
    └── Resources/              # Icons, logos, and audio references
```

---

## 🛠️ Tech Stack

| Technology | Usage |
|---|---|
| Language | C# |
| Framework | .NET Framework 4.7.2 |
| UI | Windows Forms |
| Audio | WMPLib (Windows Media Player COM) |
| Build | Visual Studio / MSBuild |

---

### Controls

| Action | Key |
|---|---|
| Move left / right | ← → Arrow keys |
| Jump | Space |
| Shoot laser | Enter |
| Pong paddle up / down | ↑ ↓ Arrow keys |

---
