# Coding Assessment for Related Digital
## Mars Explorer Position Calculator

A squad of robotic rovers will explore a rectangular plateau on Mars. We need to calculate the positions of the robotic rovers.

1. A rover's position is made from location and heading. It is represented by a combination of x and y co-ordinates and a letter which describes one of the four cardinal compass points.
	- x and y co-ordinate values are integer
	- Cardinal compass point representing letter are N for North, E for East, S for South and W for west
	- Position format is "{x} {y} {L}" where x and y are coordinate values and L is compass point representing letter

2. A rovers movement is controlled by control signal which is represented by a letter
	- Control signal L is sent for 90 degrees rover spin to left without moving from its current spot
	- Control signal R is sent for 90 degrees rover spin to right without moving from its current spot
	- Control signal M is sent for move rover forward one grid point, andmaintain the same heading

3. Lower-left coordinates are assumed to be 0 0

4. The first line of movement calculator input is the upper-right coordinates of the plateau in format of "{x} {y}"

5. The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input.
	- The first line gives the rover's position in position format
	- The second line is a series of control signals telling the rover how to explore the plateau in format of "{C1}{C2}{C3}"

6. Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving.
7. The output for each rover should be its final co-ordinates and heading in position format.

For example, expected output for the provided input is as follows.

**Input**

	- 5 5
	- 1 2 N
	- LMLMLMLMM
	- 3 3 E
	- MMRMMRMRRM

**Output**

	- 1 3 N
	- 5 1 E

##### Technical Expectations:
1. Minimum %50-unit testing code coverage.
2. GitHub repository for the assessment should be created.
3. Coding should be done with frequent commits.
4. .Net Core Framework should be used.

The assessment is designed to be easily completed within 3 hours. If the technical expectations are satisfied, resting and taking breaks during the assessment till the deadline is allowed. Thus, no time pressure will be applied for this assessment but deadline.
