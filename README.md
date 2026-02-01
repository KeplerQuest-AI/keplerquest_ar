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

## License

This project is released under the
Creative Commons Attribution–NonCommercial 4.0 International (CC BY-NC 4.0) license.

---
 
## Citation

If you use or adapt this code, please cite the corresponding paper presented at the
2026 IEEE Global Engineering Education Conference (EDUCON).

