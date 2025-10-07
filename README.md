# Survival of the Bulge

A tactical combat game where players navigate through multiple zones, engage enemy soldiers, destroy strategic targets, and collect vital game objects. Built with C# and XNA/MonoGame framework.

## 🎮 About The Game

Survival of the Bulge is an action-packed combat game that challenges players to complete mission objectives across different battlefield zones. Fight through enemy territory, destroy enemy silos, collect strategic items, and survive against waves of hostile soldiers in an atmospheric environment with dynamic weather effects.

## ✨ Key Features

- **Multi-Zone Battlefield**: Navigate through distinct combat zones, each with unique layouts and challenges
- **Enemy AI Combat**: Face intelligent enemy soldiers with varied behaviors and tactics
- **Strategic Objectives**: 
  - Destroy enemy silos to cripple their defenses
  - Locate and collect critical game objects
  - Complete zone-specific missions
- **Dynamic Environment**: Atmospheric falling leaves effect that adds immersion to the battlefield
- **Tactical Gameplay**: Plan your approach, manage resources, and adapt to enemy patterns

## 🎯 Game Objectives

1. **Eliminate Enemy Forces**: Battle hostile soldiers throughout multiple zones
2. **Destroy Silos**: Take out enemy strategic installations to complete mission objectives
3. **Collect Items**: Find and gather important game objects scattered across the battlefield
4. **Survive**: Navigate through dangerous zones while managing health and resources
5. **Complete All Zones**: Progress through different areas to achieve victory

## 🗺️ Zones

The game features multiple distinct combat zones:
- **Crashsite** - The starting area where your mission begins
- **Enemy Territory** - Navigate through hostile zones controlled by enemy forces
- **Silo Locations** - Strategic areas containing enemy installations to destroy
- **Item Zones** - Areas containing collectible game objects

## 🛠️ Built With

- **C#** - Core game logic and mechanics
- **XNA / MonoGame** - Game development framework
- **Visual Studio** - Development environment
- **Custom Game Engine** - Built-in physics and collision systems

## 🎮 Controls

- **Arrow Keys / WASD** - Move player
- **Spacebar / Left Mouse** - Shoot/Attack
- **E / Interact Key** - Collect objects
- **ESC** - Pause menu
- **[Add other controls based on your implementation]**

## 📁 Project Structure

```
survival-of-the-bulge/
├── Game.cs                  # Main game loop
├── Player.cs               # Player mechanics and controls
├── Enemy.cs                # Enemy AI and behavior
├── Silo.cs                 # Destructible silo objects
├── GameObject.cs           # Collectible items system
├── Zone/                   # Different battlefield zones
│   ├── Crashsite.cs
│   ├── EnemyTerritory.cs
│   └── SiloZone.cs
├── Effects/                # Visual effects
│   └── FallingLeaves.cs   # Atmospheric leaf particle system
├── Assets/                 # Game sprites and resources
└── Maps/                   # Zone layouts and designs
```

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2019 or later
- MonoGame 3.8 or later
- .NET Framework 4.7.2+

### Installation

1. Clone the repository
```bash
git clone https://github.com/cloudsaber/survival-of-the-bulge.git
```

2. Open the solution file in Visual Studio

3. Restore NuGet packages

4. Build and run the project (F5)

### Running the Game

1. Launch the game from Visual Studio or the compiled executable
2. Start a new game from the main menu
3. Follow on-screen objectives to progress through zones
4. Defeat enemies, destroy silos, and collect objects to win

## 🎨 Game Features Breakdown

### Combat System
- Real-time combat mechanics
- Multiple enemy types with different AI behaviors
- Health and damage system
- Weapon mechanics

### Environmental Effects
- Atmospheric falling leaves particle system
- Dynamic weather effects
- Zone-specific visual themes

### Objective System
- Track mission objectives in real-time
- Multiple objective types (eliminate, destroy, collect)
- Progress tracking across zones

## 🎓 Technical Highlights

- **Object-Oriented Design**: Modular class structure for easy maintenance
- **Collision Detection**: Custom physics system for player, enemies, and projectiles
- **AI Implementation**: Enemy pathfinding and combat behaviors
- **Particle Systems**: Dynamic environmental effects (falling leaves)
- **State Management**: Game state handling across different zones

## 🔧 Development

This project was developed as coursework to demonstrate:
- Game development principles
- Object-oriented programming in C#
- Real-time combat systems
- Level design and zone management
- Particle effects and environmental design

## 📊 Game Mechanics

### Player Mechanics
- Movement and navigation
- Combat and shooting
- Health management
- Object interaction and collection

### Enemy AI
- Patrol behaviors
- Player detection and pursuit
- Combat engagement
- Strategic positioning around silos

### Destructible Objects
- Silo destruction mechanics
- Collision-based damage system
- Visual feedback on destruction

## 🎯 Future Enhancements

- Additional zones and levels
- New enemy types and behaviors
- Power-ups and weapon upgrades
- Boss encounters
- Multiplayer support
- Enhanced visual effects
- Save/load game functionality
- Achievements system

## 📸 Screenshots

[Add screenshots of your game here showing:]
- Different zones
- Combat encounters
- Falling leaves effect
- Silo destruction
- UI and HUD

## 👤 Author

**[Romeo Mcdonald]**
- GitHub: [@Ghoulbinder](https://github.com/Ghoulbinder)
- University Coursework Project

## 📄 License

This project was created as part of university coursework. Please contact for usage permissions.

## 🙏 Acknowledgments

- MonoGame community and documentation
- XNA Framework resources
- Game design inspiration from tactical combat games
- University lecturers and course materials

---

⭐ If you enjoyed this game or found the code useful, please consider giving it a star!
