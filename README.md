# Codec
Codec program is a robot navigation program that will navigate on Mars terrain.
The input of the app will be a series of commands to move the robot on the plateau. Mars plateau is a grid defined by the initial input of the app, such as 5x5, 3x4, etc.\
The second input line will be a string containing multiple commands as described below:\
L: Turn the robot left\
R: Turn the robot right\
F: Move forward on it's facing direction\

## Requirements:
-The robot will always start at **X: 1, Y: 1**\
-Robot's facing direction is **NORTH**.

### Example:
#### Input:
```bash
12x5\
RFLFFF
```
#### Result:
```bash
2,4,North
```
- There is no limit for the Plateau size
- Inputs will always be valid, so there is no need to validate them
- There is no 0,0 position
