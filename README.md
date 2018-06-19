# Mars-Rover-Solution
A solution to the Mars Rover problem using TDD

A Mars Rover has been developed to map out the landscape. It's a small robot which can move on a grid, controlled by simple commands.
In this example, it will move on a 5x5 grid with a simple co-ordinate system - 0,0 is the bottom left, 4,4 is the top right.
We can control the Rover by sending it a string consisting of commands, such as the following: RFLFFRF
R means rotate right 90 degrees, L rotate left 90 degrees, and F means move forward one square in the direction the Rover is currently facing. The Rover starts at 0,0 facing North ("up" the grid).
We need a program which will accept strings of commands at the command line, and return the grid position of the Rover after those commands.
