Welcome to "Night Library" — a kid-friendly horror prototype for Grade 6 (PC & Mobile)

Overview
- Target age: Grade 6 (~11-12 years old)
- Tone: Spooky / suspenseful, non-violent, no gore, no realistic threats.
- Platforms: PC (Windows/Mac) and Mobile (Android/iOS)
- Engine: Recommended: Unity 2020.3 LTS or newer. Alternative: Godot 4.

Contents
- GDD.md — Game Design Document (full concept & asset list)
- PlayerController.cs — basic movement, flashlight, interact (for PC & mobile)
- TouchControls.cs — simple virtual joystick & tap input glue
- GameManager.cs — manages simple scares, objectives, and game state

How to prototype quickly
1. Create Unity 3D project.
2. Add a Character (Capsule), add a CharacterController component.
3. Create a Camera as a child of the player capsule, positioned at "head" height.
4. Create a Directional Light (daylight), but set ambient low — the scene should be dim.
5. Create a point light attached to the camera (this will be the flashlight).
6. Add simple colliders (walls, floor), a few door objects (with BoxCollider), and 1–3 Trigger volumes for "scare events".
7. Drop PlayerController.cs on the player capsule; assign the Camera and flashlight Light.
8. Optionally, add TouchControls.cs and wire its joystick to PlayerController (only needed for mobile).
9. Put GameManager.cs anywhere and tag the scare triggers with "ScareTrigger" or call events via inspector.

Art & Audio tips
- Art style: Stylized / cartoonish, high-contrast silhouettes, warm desaturated palette to keep it non-threatening.
- SFX: Ambient wind, creak, distant whisper (soft), subtle jump-sounds that are short and non-violent.
- Music: Use slow, minor-key pads and avoid heavy percussion.

Safety & Content guidelines
- No gore, no graphic images, no violent actions. Use suspense and puzzles.
- Include a "calm" mode where jump-scares are disabled for sensitive players.
- Provide parental guidance text in the main menu.

If you want, I can:
- Provide a ready-to-import Unity scene (.unity) with prefabs and basic art placeholders.
- Convert scripts to Godot (GDScript).
- Add a simple UI and an options menu (sound, difficulty, calm mode).
