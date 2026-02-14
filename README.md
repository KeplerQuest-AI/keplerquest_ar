# keplerquest_ar

This repository contains the **Augmented Reality (AR) client** developed for the KeplerQuest-AI framework.  
The client is implemented in **Unity** and provides interactive visualizations to support the learning of **Kepler’s laws of planetary motion** through spatial and exploratory representations.

The implementation corresponds to the AR component described in the paper presented at the  
**2026 IEEE Global Engineering Education Conference (EDUCON)** and is released to ensure **reproducibility and reuse** of the visualization technology.

---

## Overview

The AR client provides an immersive environment that enables learners to:
- Explore orbital motion through interactive 3D models
- Observe geometric and kinematic relationships underlying Kepler’s laws
- Support inquiry-driven reasoning when used alongside an external conversational system

While originally designed to complement an LLM-based chatbot backend, the AR client can operate independently as a standalone visualization tool.

---

## Technology Stack

- **Engine:** Unity
- **Platform:** Augmented Reality (mobile devices)
- **AR Framework:** Unity-compatible AR stack (e.g., AR Foundation / Vuforia, depending on local setup)
- **Design Approach:** Modular scenes and scripts for reuse and extension

---

## Repository Scope

This repository provides **only the augmented reality visualization infrastructure**.
It does not include:
- Conversational logic or AI components
- Learning activities or instructional scripts
- Assessment or analytics tools

The AR client is domain-focused on **planetary motion and Kepler’s laws**, but its structure is reusable for other STEM visualization contexts involving spatial or dynamic phenomena.

---

## Project Structure

The Unity project follows standard conventions:

```text
Assets/           # AR scenes, scripts, models, and resources
Packages/         # Unity Package Manager dependencies
ProjectSettings/  # Unity project configuration
```
---

## Reproducibility Notes

### Vuforia Dependency (Required)

This repository **does not include the Vuforia Engine package** due to licensing and file size constraints.

To reproduce the AR application, Vuforia must be installed manually:

1. Open the project in **Unity 2022.3 LTS**.
2. Go to **Window → Package Manager**.
3. Select **My Assets** and install **Vuforia Engine version 11.3.4**.
4. Ensure the package is correctly resolved by Unity (it will be registered under `Packages/`).

The project was tested with **Vuforia Engine 11.3.4**. Other versions may cause compatibility issues.

---

### Running the AR Scene

For the first execution:

1. In the Unity Project window, navigate to: `Assets/Scenes/`
2. Open the scene `KeplerQuest.unity` manually.
3. Press **Play** in the Unity Editor.

---

### AR Targets

The AR visualizations are triggered using image targets:

- The target images are located in: `Assets/Targets/`
- Display these images in front of your device camera (printed or on-screen) while the scene is running.
- When a target is detected, the corresponding orbital animations and visualizations will appear.

---

### Notes

If the project opens but appears empty, ensure that:
- `KeplerQuest.unity` is the active scene
- Vuforia is correctly installed
- All `.meta` files are present in the `Assets/` folder


---

## License

This project is released under the
Creative Commons Attribution–NonCommercial 4.0 International (CC BY-NC 4.0) license.

---
 
## Citation

If you use or adapt this code, please cite the corresponding paper presented at the
2026 IEEE Global Engineering Education Conference (EDUCON).

