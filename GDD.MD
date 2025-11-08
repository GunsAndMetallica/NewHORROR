Title: Night Library — Kid-Friendly Horror (Grade 6)

High-level concept
- Player wakes in a quiet school library after hours. Lights are out. The goal is to find three "lost books" and exit.
- Gameplay relies on exploration, simple puzzles, and mild jump-scares. No violence, no gore.
- Lesson tie-in optional: reading clues to solve puzzles (supports literacy).

Target audience
- Age: Grade 6 (11–12 years)
- Tone: Suspense + curiosity. Scares are mild and non-graphic.

Gameplay Loop
1. Explore a small map (library + adjacent hallway).
2. Use a flashlight to reveal clues and read notes.
3. Solve small puzzles (unlock cabinet, reorder books by color/subject, match a symbol).
4. Collect 3 lost books; return to the desk to finish.
5. Optional "calm mode": disables all jump-scares, keeps puzzles.

Mechanics
- Movement: First-person (PC: WASD + mouse; Mobile: virtual joystick + drag to look).
- Flashlight: Toggleable light with limited battery (optional) — battery recharges at charging station.
- Interact: Raycast-based interaction (press E/tap to pick up/read).
- Puzzles: Non-timed, logic-based (arranging books, simple pattern matching).
- Scares: Audio + lighting spikes, ephemeral silhouette or shadow movement. No physical harm.

Level Design (prototype)
- Start area: librarian desk (objective shows “Find 3 lost books”).
- Main area: stacks with aisles (uses occlusion to hide things).
- Side room: storage/closet for one puzzle.
- Exit: main doors that open when books returned.

Accessibility & Safety
- Adjustable difficulty (puzzle hints, calm mode).
- Brightness slider and colorblind-friendly palette options.
- Parental info in menu; optional quick "exit to bright lobby" button.

Assets (prototype)
- Models: simple low-poly shelves, tables, doors, book prefabs.
- Textures: stylized, low-detail to keep focus on gameplay.
- Audio: ambient loop, creaks, page rustle, soft jump-sound.
- UI: large readable fonts, simple icons.

Controls
- PC:
  - Move: WASD or arrows
  - Look: Mouse
  - Interact: E / Left click
  - Flashlight: F
  - Pause/Menu: Esc
- Mobile:
  - Virtual joystick (left) for movement — TouchControls.cs
  - Swipe on right side to look / drag to rotate camera
  - Tap interact button or double-tap center
  - Flashlight button on HUD

Tech Stack & Tools
- Unity (C#) recommended for cross-platform builds, light on custom code.
- Alternative: Godot 4 (GDScript) — smaller footprint.
- Audio: Audacity / royalty-free SFX (ensure license for children-friendly content).
- Art: Blender for low-poly assets or free assets from stores.

Prototype scope (2–6 weeks)
- Week 1: Core movement, flashlight, interactions, simple scene.
- Week 2: Implement puzzles and one scare type; basic UI.
- Week 3: Polish, accessibility settings, playtesting with children (observe comfort).
- Week 4+: Add more content, polish art/audio.

Monetization / Release
- Educational or premium one-time purchase preferred for kids.
- Avoid ads or in-app purchases aimed at children (check local regulations).

Playtesting & moderation
- Test with children under supervision; measure startle level and emotional response.
- Provide an "exit to lobby" button that immediately returns player to a safe, bright scene.

Notes for teachers/parents
- Great for lessons about reading comprehension, pattern recognition, and following instructions.
- Use calm mode for sensitive students.

End of GDD.
